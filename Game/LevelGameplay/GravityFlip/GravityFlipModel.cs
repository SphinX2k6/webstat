using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.GravityFlip
{
	// Token: 0x02006E7D RID: 28285
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class GravityFlipModel : ModelBase<GravityFlipModel>
	{
		// Token: 0x060449A1 RID: 280993 RVA: 0x011D5883 File Offset: 0x011D3A83
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x060449A2 RID: 280994 RVA: 0x011D5886 File Offset: 0x011D3A86
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x060449A3 RID: 280995 RVA: 0x011D588C File Offset: 0x011D3A8C
		[NullableContext(1)]
		public void InitGravityFlipParams(SceneItemGravityFlipComponent gravityFlipComp)
		{
			this.GravityFlipComp = gravityFlipComp;
			this.GravityFlipEntity = gravityFlipComp.Entity;
			this.ValidGravityDirections.Clear();
			this.CurrentGravityDirection = gravityFlipComp.CurGravityDirection;
			List<IGravityFlipConfig> gravityFlipDirection = gravityFlipComp.GetGravityFlipDirection();
			if (gravityFlipDirection == null || gravityFlipDirection.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[GravityFlipModel] 未找到重力方向配置";
				string item = "PbDataId";
				CreatureDataComponent component = gravityFlipComp.Entity.GetComponent<CreatureDataComponent>();
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (component != null) ? new int?(component.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			using (List<IGravityFlipConfig>.Enumerator enumerator = gravityFlipDirection.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					switch (enumerator.Current.Type)
					{
					case EGravityFlipType.Up:
						this.ValidGravityDirections.Add(EGravityDirection.Up);
						break;
					case EGravityFlipType.Down:
						this.ValidGravityDirections.Add(EGravityDirection.Down);
						break;
					case EGravityFlipType.Left:
						this.ValidGravityDirections.Add(EGravityDirection.Left);
						break;
					case EGravityFlipType.Right:
						this.ValidGravityDirections.Add(EGravityDirection.Right);
						break;
					}
				}
			}
			this.GravityFlipComp.OnEnterInteract();
		}

		// Token: 0x060449A4 RID: 280996 RVA: 0x011D59CC File Offset: 0x011D3BCC
		public bool NeedChangeGravity()
		{
			return this.GravityFlipComp.CurGravityDirection != this.CurrentGravityDirection;
		}

		// Token: 0x1700A39B RID: 41883
		// (get) Token: 0x060449A5 RID: 280997 RVA: 0x011D59E4 File Offset: 0x011D3BE4
		public long GravityFlipEntityCreatureDataId
		{
			get
			{
				Entity gravityFlipEntity = this.GravityFlipEntity;
				long? num;
				if (gravityFlipEntity == null)
				{
					num = null;
				}
				else
				{
					CreatureDataComponent component = gravityFlipEntity.GetComponent<CreatureDataComponent>();
					num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
				}
				long? num2 = num;
				return num2.GetValueOrDefault();
			}
		}

		// Token: 0x060449A6 RID: 280998 RVA: 0x011D5A2C File Offset: 0x011D3C2C
		private GravityFlipType ConvertGravityDirectionToProtoType(EGravityDirection direction)
		{
			if (direction <= EGravityDirection.Left)
			{
				if (direction == EGravityDirection.Down)
				{
					return GravityFlipType.GravityDown;
				}
				if (direction == EGravityDirection.Left)
				{
					return GravityFlipType.GravityLeft;
				}
			}
			else
			{
				if (direction == EGravityDirection.Up)
				{
					return GravityFlipType.GravityUp;
				}
				if (direction == EGravityDirection.Right)
				{
					return GravityFlipType.GravityRight;
				}
			}
			return GravityFlipType.GravityDown;
		}

		// Token: 0x1700A39C RID: 41884
		// (get) Token: 0x060449A7 RID: 280999 RVA: 0x011D5A58 File Offset: 0x011D3C58
		public GravityFlipType CurGravityFlipType
		{
			get
			{
				return this.ConvertGravityDirectionToProtoType(this.CurrentGravityDirection);
			}
		}

		// Token: 0x1700A39D RID: 41885
		// (get) Token: 0x060449A8 RID: 281000 RVA: 0x011D5A68 File Offset: 0x011D3C68
		public EGravityDirection TargetDirection
		{
			get
			{
				Entity gravityFlipEntity = this.GravityFlipEntity;
				BaseTagComponent baseTagComponent = (gravityFlipEntity != null) ? gravityFlipEntity.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent == null)
				{
					return EGravityDirection.None;
				}
				if (baseTagComponent.GetTagCount(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.重力机关.重力方向提示"]) != 1)
				{
					return EGravityDirection.None;
				}
				if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.重力机关.重力方向提示.上"]))
				{
					return EGravityDirection.Up;
				}
				if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.重力机关.重力方向提示.下"]))
				{
					return EGravityDirection.Down;
				}
				if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.重力机关.重力方向提示.左"]))
				{
					return EGravityDirection.Left;
				}
				if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.重力机关.重力方向提示.右"]))
				{
					return EGravityDirection.Right;
				}
				return EGravityDirection.None;
			}
		}

		// Token: 0x060449A9 RID: 281001 RVA: 0x011D5B18 File Offset: 0x011D3D18
		protected override bool OnChangeMode()
		{
			SceneItemGravityFlipComponent gravityFlipComp = this.GravityFlipComp;
			if (gravityFlipComp == null || !gravityFlipComp.IsInteracting)
			{
				return true;
			}
			GravityFlipViewOpenParam param = new GravityFlipViewOpenParam
			{
				SelectCallback = this.ViewCallBackCache
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GravityFlipView, param, null);
			return true;
		}

		// Token: 0x040262FD RID: 156413
		public Entity GravityFlipEntity;

		// Token: 0x040262FE RID: 156414
		public SceneItemGravityFlipComponent GravityFlipComp;

		// Token: 0x040262FF RID: 156415
		public GravityFlipType CacheCorrectDirection = GravityFlipType.GravityDown;

		// Token: 0x04026300 RID: 156416
		public EGravityDirection CurrentGravityDirection;

		// Token: 0x04026301 RID: 156417
		[Nullable(1)]
		public List<EGravityDirection> ValidGravityDirections = new List<EGravityDirection>();

		// Token: 0x04026302 RID: 156418
		public Action<int> ViewCallBackCache;
	}
}
