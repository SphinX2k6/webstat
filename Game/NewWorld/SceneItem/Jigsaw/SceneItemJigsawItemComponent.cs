using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Jigsaw
{
	// Token: 0x02004862 RID: 18530
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemJigsawItemComponent : EntityComponent
	{
		// Token: 0x1700827B RID: 33403
		// (get) Token: 0x06030352 RID: 197458 RVA: 0x00BB7C68 File Offset: 0x00BB5E68
		// (set) Token: 0x06030353 RID: 197459 RVA: 0x00BB7C70 File Offset: 0x00BB5E70
		public JigsawIndex PutDownIndex
		{
			get
			{
				return this.PutDownIndexInternal;
			}
			set
			{
				this.PutDownIndexInternal = value;
			}
		}

		// Token: 0x1700827C RID: 33404
		// (get) Token: 0x06030354 RID: 197460 RVA: 0x00BB7C79 File Offset: 0x00BB5E79
		// (set) Token: 0x06030355 RID: 197461 RVA: 0x00BB7C81 File Offset: 0x00BB5E81
		public SceneItemJigsawBaseComponent PutDownBase
		{
			get
			{
				return this.PutDownBaseInternal;
			}
			set
			{
				this.PutDownBaseInternal = value;
			}
		}

		// Token: 0x1700827D RID: 33405
		// (get) Token: 0x06030356 RID: 197462 RVA: 0x00BB7C8A File Offset: 0x00BB5E8A
		// (set) Token: 0x06030357 RID: 197463 RVA: 0x00BB7C92 File Offset: 0x00BB5E92
		public Number Rotation
		{
			get
			{
				return this.SelfRotation;
			}
			set
			{
				this.SelfRotation = value;
			}
		}

		// Token: 0x06030358 RID: 197464 RVA: 0x00BB7C9C File Offset: 0x00BB5E9C
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			JigsawItem config = args.GetP1<CreateEntityData>().GetParam<SceneItemJigsawItemComponent>() as JigsawItem;
			this.Config = config;
			IDirectionFill directionFill = this.Config.FillCfg as IDirectionFill;
			IFixedFill fixedFill = this.Config.FillCfg as IFixedFill;
			EFillType type = this.Config.FillCfg.Type;
			if (type != EFillType.Fixed)
			{
				if (type != EFillType.Direction)
				{
					return true;
				}
			}
			else
			{
				IPieceIndex centre = fixedFill.Centre;
				this.CenterIndex = new JigsawIndex(centre.RowIndex, centre.ColumnIndex);
				using (List<IJigsawPiece>.Enumerator enumerator = fixedFill.Config.Pieces.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IJigsawPiece jigsawPiece = enumerator.Current;
						if (jigsawPiece.InitState == EJigsawPieceState.Correct)
						{
							this.ActivatedBlock.Add(new JigsawIndex(jigsawPiece.Index.RowIndex, jigsawPiece.Index.ColumnIndex));
						}
					}
					return true;
				}
			}
			if (directionFill.W)
			{
				this.Direction |= 2;
			}
			if (directionFill.S)
			{
				this.Direction |= 4;
			}
			if (directionFill.A)
			{
				this.Direction |= 8;
			}
			if (directionFill.D)
			{
				this.Direction |= 16;
			}
			JigsawIndex jigsawIndex = new JigsawIndex(0, 0);
			this.ActivatedBlock.Add(jigsawIndex);
			this.CenterIndex = jigsawIndex;
			return true;
		}

		// Token: 0x06030359 RID: 197465 RVA: 0x00BB7E18 File Offset: 0x00BB6018
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.MultiActorComp = base.Entity.GetComponent<SceneItemMultiInteractionActorComponent>();
			this.TagComp = base.Entity.GetComponent<LevelTagComponent>();
			LevelTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.被控物被锁定中"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged), null);
			}
			LevelTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null)
			{
				tagComp2.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.正确"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged), null);
			}
			LevelTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null)
			{
				tagComp3.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.错误"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged), null);
			}
			return true;
		}

		// Token: 0x0603035A RID: 197466 RVA: 0x00BB7EF4 File Offset: 0x00BB60F4
		private void OnGameplayTagChanged(int tagId, bool tagExist)
		{
			int num = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.被控物被锁定中"];
			int num2 = GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.正确"];
			int num3 = GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.错误"];
			bool flag = this.TagComp.HasTag(num2) || this.TagComp.HasTag(num3);
			bool flag2 = this.TagComp.HasTag(num);
			int tags = flag ? GameplayTagDefine.EGameplayTagId["关卡.Common.表现.控物拼图.已匹配锁定"] : GameplayTagDefine.EGameplayTagId["关卡.Common.表现.控物拼图.未匹配锁定"];
			if (tagId == num && tagExist)
			{
				foreach (JigsawIndex index in this.ActivatedBlock)
				{
					this.MultiActorComp.AddTagsByIndex(index, tagId);
					this.MultiActorComp.AddTagsByIndex(index, tags);
				}
			}
			if ((tagId == num2 || tagId == num3) && !tagExist && flag2)
			{
				foreach (JigsawIndex index2 in this.ActivatedBlock)
				{
					this.MultiActorComp.RemoveTagsByIndex(index2, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.控物拼图.已匹配锁定"]);
				}
			}
			if (tagId == num)
			{
				foreach (JigsawIndex index3 in this.ActivatedBlock)
				{
					this.MultiActorComp.RemoveTagsByIndex(index3, tagId);
					this.MultiActorComp.RemoveTagsByIndex(index3, tags);
				}
			}
		}

		// Token: 0x0603035B RID: 197467 RVA: 0x00BB80AC File Offset: 0x00BB62AC
		protected override bool OnEnd()
		{
			LevelTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.被控物被锁定中"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged));
			}
			LevelTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null)
			{
				tagComp2.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.正确"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged));
			}
			LevelTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null)
			{
				tagComp3.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["关卡.Common.属性.底座中.错误"], new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChanged));
			}
			return true;
		}

		// Token: 0x0603035C RID: 197468 RVA: 0x00BB813E File Offset: 0x00BB633E
		protected override void OnActivate()
		{
			this.GenDynamicBlock();
		}

		// Token: 0x0603035D RID: 197469 RVA: 0x00BB8148 File Offset: 0x00BB6348
		private void GenDynamicBlock()
		{
			IFixedFill fixedFill = this.Config.FillCfg as IFixedFill;
			if (fixedFill == null)
			{
				return;
			}
			if (fixedFill.Type == EFillType.Fixed)
			{
				int? modelId = fixedFill.ModelId;
				if (modelId != null && modelId.GetValueOrDefault() != 0)
				{
					List<JigsawIndex> list = new List<JigsawIndex>();
					foreach (JigsawIndex item in this.ActivatedBlock)
					{
						list.Add(item);
					}
					this.MultiActorComp.InitGenerateInfo(fixedFill.ModelId.Value.ToString(), list, (JigsawIndex index) => Vector.Create(this.GetBlockLocationByIndex(index)), null, null);
					return;
				}
				this.MultiActorComp.SetIsFinish(true);
			}
		}

		// Token: 0x0603035E RID: 197470 RVA: 0x00BB821C File Offset: 0x00BB641C
		public JigsawIndex GetCenterIndex()
		{
			return this.CenterIndex;
		}

		// Token: 0x0603035F RID: 197471 RVA: 0x00BB8224 File Offset: 0x00BB6424
		public List<JigsawIndex> GetActiveBlockOffset(int? rotation = null)
		{
			List<JigsawIndex> list = new List<JigsawIndex>();
			foreach (JigsawIndex jigsawIndex in this.ActivatedBlock)
			{
				list.Add(this.GetRotatedIndex(new JigsawIndex(jigsawIndex.Row - this.CenterIndex.Row, jigsawIndex.Col - this.CenterIndex.Col), rotation));
			}
			return list;
		}

		// Token: 0x06030360 RID: 197472 RVA: 0x00BB82B0 File Offset: 0x00BB64B0
		public void RotateSelf()
		{
			this.SelfRotation += 90;
		}

		// Token: 0x06030361 RID: 197473 RVA: 0x00BB82CC File Offset: 0x00BB64CC
		private JigsawIndex GetRotatedIndex(JigsawIndex index, int? rotation = null)
		{
			int num = (rotation ?? this.SelfRotation) / 90 % SceneItemJigsawItemComponent.sinValue.Length;
			int row = index.Row * SceneItemJigsawItemComponent.cosValue[num] - index.Col * SceneItemJigsawItemComponent.sinValue[num];
			int col = index.Row * SceneItemJigsawItemComponent.sinValue[num] + index.Col * SceneItemJigsawItemComponent.cosValue[num];
			return new JigsawIndex(row, col);
		}

		// Token: 0x06030362 RID: 197474 RVA: 0x00BB8348 File Offset: 0x00BB6548
		[return: Nullable(2)]
		public Vector GetBlockLocationByIndex(JigsawIndex index)
		{
			IFixedFill fixedFill = this.Config.FillCfg as IFixedFill;
			if ((((fixedFill != null) ? new EFillType?(fixedFill.Type) : null) ?? EFillType.Direction) != EFillType.Fixed)
			{
				return this.ActorComp.ActorLocationProxy;
			}
			if (index.Row >= fixedFill.Config.Row || index.Col >= fixedFill.Config.Column)
			{
				return null;
			}
			JigsawIndex centerIndex = this.CenterIndex;
			int num = centerIndex.Row - index.Row;
			int num2 = centerIndex.Col - index.Col;
			int size = fixedFill.Config.Size;
			Vector2D vector2D = Vector2D.Create((double)size, (double)size).MultiplyEqual(Vector2D.Create((double)num, (double)num2));
			FVectorDouble fvectorDouble = new FVectorDouble(vector2D.X, -vector2D.Y, 0.0);
			Vector vector = Vector.Create(0.0, 0.0, 0.0);
			FVectorDouble fvectorDouble2 = this.ActorComp.ActorTransform.TransformPosition(fvectorDouble);
			vector.FromUeVector(fvectorDouble2);
			return vector;
		}

		// Token: 0x06030363 RID: 197475 RVA: 0x00BB8474 File Offset: 0x00BB6674
		public void OnPutDownToBase(SceneItemJigsawBaseComponent baseComp)
		{
			this.PutDownBaseInternal = baseComp;
			foreach (JigsawIndex jigsawIndex in this.ActivatedBlock)
			{
				JigsawIndex rotatedIndex = this.GetRotatedIndex(new JigsawIndex(jigsawIndex.Row - this.CenterIndex.Row, jigsawIndex.Col - this.CenterIndex.Col), null);
				rotatedIndex.Row += this.PutDownIndex.Row;
				rotatedIndex.Col += this.PutDownIndex.Col;
				EJigsawSocketState blockStateByIndex = baseComp.GetBlockStateByIndex(rotatedIndex);
				if (blockStateByIndex != EJigsawSocketState.Correct)
				{
					if (blockStateByIndex == EJigsawSocketState.Active)
					{
						this.MultiActorComp.AddTagsByIndex(jigsawIndex, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.拼图.物件.错误位放置"]);
					}
				}
				else
				{
					this.MultiActorComp.AddTagsByIndex(jigsawIndex, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.拼图.物件.正确位放置"]);
				}
			}
		}

		// Token: 0x06030364 RID: 197476 RVA: 0x00BB8584 File Offset: 0x00BB6784
		public void OnPickUpFormBase(SceneItemJigsawBaseComponent baseComp)
		{
			this.PutDownBaseInternal = null;
			foreach (JigsawIndex jigsawIndex in this.ActivatedBlock)
			{
				JigsawIndex rotatedIndex = this.GetRotatedIndex(new JigsawIndex(jigsawIndex.Row - this.CenterIndex.Row, jigsawIndex.Col - this.CenterIndex.Col), null);
				rotatedIndex.Row += this.PutDownIndex.Row;
				rotatedIndex.Col += this.PutDownIndex.Col;
				EJigsawSocketState blockStateByIndex = baseComp.GetBlockStateByIndex(rotatedIndex);
				if (blockStateByIndex != EJigsawSocketState.Correct)
				{
					if (blockStateByIndex == EJigsawSocketState.Active)
					{
						this.MultiActorComp.RemoveTagsByIndex(jigsawIndex, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.拼图.物件.错误位放置"]);
					}
				}
				else
				{
					this.MultiActorComp.RemoveTagsByIndex(jigsawIndex, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.拼图.物件.正确位放置"]);
				}
			}
		}

		// Token: 0x06030365 RID: 197477 RVA: 0x00BB8694 File Offset: 0x00BB6894
		public void OnFinish()
		{
			foreach (JigsawIndex index in this.ActivatedBlock)
			{
				this.MultiActorComp.AddTagsByIndex(index, GameplayTagDefine.EGameplayTagId["关卡.Common.表现.拼图.物件.完成"]);
			}
		}

		// Token: 0x06030366 RID: 197478 RVA: 0x00BB86FC File Offset: 0x00BB68FC
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<bool, Vector, JigsawIndex>? GetNextMoveTargetOnHit(Vector direction)
		{
			SceneItemJigsawBaseComponent putDownBase = this.PutDownBase;
			if (putDownBase == null || !putDownBase.Valid)
			{
				return null;
			}
			JigsawIndex nextPosByDirection = this.PutDownBase.GetNextPosByDirection(this.PutDownIndex, direction, base.Entity);
			return new ValueTuple<bool, Vector, JigsawIndex>?(new ValueTuple<bool, Vector, JigsawIndex>(nextPosByDirection.GetKey() != this.PutDownIndex.GetKey(), this.PutDownBase.GetBlockLocationByIndex(nextPosByDirection, true), nextPosByDirection));
		}

		// Token: 0x06030367 RID: 197479 RVA: 0x00BB8771 File Offset: 0x00BB6971
		public void OnMove(JigsawIndex targetIndex)
		{
			this.PutDownBase.OnItemMove(this, targetIndex);
		}

		// Token: 0x06030368 RID: 197480 RVA: 0x00BB8780 File Offset: 0x00BB6980
		public void RemoveMagnetTipsTag()
		{
			this.PutDownBase.RemoveMagnetTipsTag(this.PutDownIndex);
		}

		// Token: 0x06030369 RID: 197481 RVA: 0x00BB8794 File Offset: 0x00BB6994
		public List<Vector> GetAllActivatedBlockPos()
		{
			List<Vector> list = new List<Vector>();
			foreach (JigsawIndex index in this.ActivatedBlock)
			{
				Vector blockLocationByIndex = this.GetBlockLocationByIndex(index);
				if (blockLocationByIndex != null)
				{
					list.Add(Vector.Create(blockLocationByIndex));
				}
			}
			return list;
		}

		// Token: 0x0603036A RID: 197482 RVA: 0x00BB8800 File Offset: 0x00BB6A00
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemJigsawItemComponent sceneItemJigsawItemComponent = (SceneItemJigsawItemComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemJigsawItemComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<JigsawItem>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemJigsawItemComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemJigsawItemComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MultiActorComp"))
			{
				if (sceneItemJigsawItemComponent.MultiActorComp == null)
				{
					this.MultiActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMultiInteractionActorComponent>(this.MultiActorComp), "MultiActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (sceneItemJigsawItemComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Direction"))
			{
				this.Direction = sceneItemJigsawItemComponent.Direction;
			}
			if (base.CanResetComponentProperty("ActivatedBlock") && sceneItemJigsawItemComponent.ActivatedBlock != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<JigsawIndex>>(this.ActivatedBlock), "ActivatedBlock"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CenterIndex"))
			{
				if (sceneItemJigsawItemComponent.CenterIndex == null)
				{
					this.CenterIndex = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<JigsawIndex>(this.CenterIndex), "CenterIndex"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PutDownIndexInternal"))
			{
				if (sceneItemJigsawItemComponent.PutDownIndexInternal == null)
				{
					this.PutDownIndexInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<JigsawIndex>(this.PutDownIndexInternal), "PutDownIndexInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PutDownBaseInternal"))
			{
				if (sceneItemJigsawItemComponent.PutDownBaseInternal == null)
				{
					this.PutDownBaseInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemJigsawBaseComponent>(this.PutDownBaseInternal), "PutDownBaseInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SelfRotation"))
			{
				this.SelfRotation = sceneItemJigsawItemComponent.SelfRotation;
			}
			return true;
		}

		// Token: 0x0603036C RID: 197484 RVA: 0x00BB8A60 File Offset: 0x00BB6C60
		// Note: this type is marked as 'beforefieldinit'.
		static SceneItemJigsawItemComponent()
		{
			int[] array = new int[4];
			array[0] = 1;
			array[2] = -1;
			SceneItemJigsawItemComponent.cosValue = array;
		}

		// Token: 0x0401BAF1 RID: 113393
		[StaticVariableRuleIgnore]
		private static readonly int[] sinValue = new int[]
		{
			0,
			1,
			0,
			-1
		};

		// Token: 0x0401BAF2 RID: 113394
		[StaticVariableRuleIgnore]
		private static readonly int[] cosValue;

		// Token: 0x0401BAF3 RID: 113395
		[Nullable(2)]
		public JigsawItem Config;

		// Token: 0x0401BAF4 RID: 113396
		[Nullable(2)]
		public CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BAF5 RID: 113397
		[Nullable(2)]
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401BAF6 RID: 113398
		[Nullable(2)]
		private SceneItemMultiInteractionActorComponent MultiActorComp;

		// Token: 0x0401BAF7 RID: 113399
		[Nullable(2)]
		private LevelTagComponent TagComp;

		// Token: 0x0401BAF8 RID: 113400
		public int Direction;

		// Token: 0x0401BAF9 RID: 113401
		private readonly List<JigsawIndex> ActivatedBlock = new List<JigsawIndex>();

		// Token: 0x0401BAFA RID: 113402
		[Nullable(2)]
		private JigsawIndex CenterIndex;

		// Token: 0x0401BAFB RID: 113403
		[Nullable(2)]
		private JigsawIndex PutDownIndexInternal;

		// Token: 0x0401BAFC RID: 113404
		[Nullable(2)]
		private SceneItemJigsawBaseComponent PutDownBaseInternal;

		// Token: 0x0401BAFD RID: 113405
		private Number SelfRotation = 0;
	}
}
