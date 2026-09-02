using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LifePoint
{
	// Token: 0x02006B48 RID: 27464
	[NullableContext(1)]
	[Nullable(0)]
	public class Grid : UiPanelBase
	{
		// Token: 0x06043DAC RID: 277932 RVA: 0x01189FD6 File Offset: 0x011881D6
		public Grid(int x, int y, EPieceColorType color, Action<int, int> callback)
		{
			this.X = x;
			this.Y = y;
			this.Color = color;
			this.Callback = callback;
			this.ColorExpressed = color;
		}

		// Token: 0x06043DAD RID: 277933 RVA: 0x0118A010 File Offset: 0x01188210
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043DAE RID: 277934 RVA: 0x0118A0FD File Offset: 0x011882FD
		protected override void OnBeforeCreate()
		{
			this.UiViewSequence = new UiBehaviorLevelSequence(this);
			base.AddUiBehavior(this.UiViewSequence);
		}

		// Token: 0x06043DAF RID: 277935 RVA: 0x0118A118 File Offset: 0x01188318
		protected override void OnStart()
		{
			this.IsBlock = (this.ColorExpressed == EPieceColorType.Gray);
			UTexture2D texture;
			ModelBase<LifePointModel>.Instance.GridTextureMap.TryGetValue(this.Color, out texture);
			base.GetTexture(0).SetTexture(texture);
			bool uiactive = this.Color == ModelBase<LifePointModel>.Instance.Config.ColorBoard.TargetColor;
			base.GetTexture(2).GetParentAsUIItem().SetUIActive(uiactive);
			UTexture2D texture2;
			ModelBase<LifePointModel>.Instance.HitGridTextureMap.TryGetValue(this.Color, out texture2);
			base.GetTexture(2).SetTexture(texture2);
			base.GetTexture(1).GetParentAsUIItem().SetUIActive(false);
			base.GetTexture(3).GetParentAsUIItem().SetUIActive(false);
			base.GetTexture(5).SetUIActive(this.IsBlock);
			base.GetItem(4).SetUIActive(!this.IsBlock);
			if (!this.IsBlock)
			{
				(base.GetRootActor().GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent).OnClickCallBack.Bind(new Action(this.OnClick));
			}
		}

		// Token: 0x06043DB0 RID: 277936 RVA: 0x0118A230 File Offset: 0x01188430
		protected override void OnBeforeDestroy()
		{
			(base.GetRootActor().GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent).OnClickCallBack.Unbind();
			this.UiViewSequence.StopSequenceByKey("Change", false, false);
			this.UiViewSequence = null;
		}

		// Token: 0x06043DB1 RID: 277937 RVA: 0x0118A26F File Offset: 0x0118846F
		private void OnClick()
		{
			this.Callback(this.X, this.Y);
		}

		// Token: 0x06043DB2 RID: 277938 RVA: 0x0118A288 File Offset: 0x01188488
		public void Paint(EPieceColorType color, int order, EDirection direction)
		{
			this.Color = color;
			float num = ModelBase<LifePointModel>.Instance.CalcCountDownTime(order);
			AnimTask animTask = AnimTask.Get((float)Singleton<Time>.Instance.Now + num, color, ModelBase<LifePointModel>.Instance.DirectionParam[direction], ModelBase<LifePointModel>.Instance.CalPlayRate(num), order);
			while (this.AnimTask_.Size > 0 && this.AnimTask_.Rear.Time >= animTask.Time)
			{
				this.AnimTask_.RemoveRear();
			}
			this.AnimTask_.AddRear(animTask);
		}

		// Token: 0x06043DB3 RID: 277939 RVA: 0x0118A318 File Offset: 0x01188518
		public void TryBlendAnim(EPieceColorType color, int order, EDirection direction)
		{
			double a = Singleton<Time>.Instance.Now + (double)ModelBase<LifePointModel>.Instance.CalcCountDownTime(order);
			for (int i = 0; i < this.AnimTask_.Size; i++)
			{
				AnimTask animTask = this.AnimTask_.Get(i);
				if (animTask != null && animTask.Color == color && Singleton<MathUtils>.Instance.IsNearlyEqual(a, (double)animTask.Time, new double?((double)1)))
				{
					animTask.DirectionParam = ModelBase<LifePointModel>.Instance.BlendDirectionParam(animTask.DirectionParam, direction);
					return;
				}
			}
		}

		// Token: 0x06043DB4 RID: 277940 RVA: 0x0118A39F File Offset: 0x0118859F
		public void BeforeReset()
		{
			this.AnimTask_.Clear();
		}

		// Token: 0x06043DB5 RID: 277941 RVA: 0x0118A3AC File Offset: 0x011885AC
		public void Reset(EPieceColorType color)
		{
			if (this.IsBlock)
			{
				return;
			}
			Dictionary<EPieceColorType, UTexture2D> dictionary = (this.ColorExpressed == ModelBase<LifePointModel>.Instance.Config.ColorBoard.TargetColor) ? ModelBase<LifePointModel>.Instance.HitGridTextureMap : ModelBase<LifePointModel>.Instance.GridTextureMap;
			this.UiViewSequence.StopPrevSequence(false, true);
			UUITexture texture = base.GetTexture(1);
			UUITexture texture2 = base.GetTexture(3);
			texture.SetTexture(dictionary[this.ColorExpressed]);
			texture2.SetTexture(dictionary[this.ColorExpressed]);
			texture.GetParentAsUIItem().SetUIActive(true);
			texture2.GetParentAsUIItem().SetUIActive(true);
			bool isHit = color == ModelBase<LifePointModel>.Instance.Config.ColorBoard.TargetColor;
			UTexture2D baseTexture = ModelBase<LifePointModel>.Instance.GridTextureMap[color];
			UTexture2D spTexture = ModelBase<LifePointModel>.Instance.HitGridTextureMap[color];
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.GetTexture(0).SetTexture(baseTexture);
				this.GetTexture(2).GetParentAsUIItem().SetUIActive(isHit);
				this.GetTexture(2).SetTexture(spTexture);
			}, null, null);
			this.Color = color;
			this.ColorExpressed = this.Color;
		}

		// Token: 0x06043DB6 RID: 277942 RVA: 0x0118A4D0 File Offset: 0x011886D0
		public void AfterReset()
		{
			base.GetTexture(1).GetParentAsUIItem().SetUIActive(false);
			base.GetTexture(3).GetParentAsUIItem().SetUIActive(false);
			base.GetTexture(1).SetColor(ModelBase<LifePointModel>.Instance.InitColor);
			base.GetTexture(3).SetColor(ModelBase<LifePointModel>.Instance.InitColor);
		}

		// Token: 0x06043DB7 RID: 277943 RVA: 0x0118A530 File Offset: 0x01188730
		public bool CheckAnim()
		{
			if (this.AnimTask_.Size == 0)
			{
				return this.UiViewSequence.IsInSequence();
			}
			if ((double)this.AnimTask_.Front.Time > Singleton<Time>.Instance.Now)
			{
				return true;
			}
			AnimTask animTask = this.AnimTask_.RemoveFront();
			this.PlayAnim(animTask);
			animTask.Recycle();
			return true;
		}

		// Token: 0x06043DB8 RID: 277944 RVA: 0x0118A590 File Offset: 0x01188790
		private void PlayAnim(AnimTask animTask)
		{
			bool isHit = animTask.Color == ModelBase<LifePointModel>.Instance.Config.ColorBoard.TargetColor;
			Dictionary<EPieceColorType, UTexture2D> dictionary = (this.ColorExpressed == ModelBase<LifePointModel>.Instance.Config.ColorBoard.TargetColor) ? ModelBase<LifePointModel>.Instance.HitGridTextureMap : ModelBase<LifePointModel>.Instance.GridTextureMap;
			UTexture2D baseTexture = ModelBase<LifePointModel>.Instance.GridTextureMap[animTask.Color];
			UTexture2D spTexture = ModelBase<LifePointModel>.Instance.HitGridTextureMap[animTask.Color];
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.GetTexture(0).SetTexture(baseTexture);
				this.GetTexture(2).GetParentAsUIItem().SetUIActive(isHit);
				this.GetTexture(2).SetTexture(spTexture);
			}, null, null);
			UUITexture texture = base.GetTexture(1);
			UUITexture texture2 = base.GetTexture(3);
			texture.SetTexture(dictionary[this.ColorExpressed]);
			texture2.SetTexture(dictionary[this.ColorExpressed]);
			texture.GetParentAsUIItem().SetUIActive(true);
			texture2.GetParentAsUIItem().SetUIActive(true);
			if (animTask.DirectionParam < 0f)
			{
				if (this.UiViewSequence.HasSequenceNameInPlaying("PointChange"))
				{
					this.UiViewSequence.ReplaySequence("PointChange");
				}
				else
				{
					this.UiViewSequence.PlaySequence("PointChange", false, null);
				}
			}
			else
			{
				texture.SetCustomMaterialScalarParameter(ModelBase<LifePointModel>.Instance.ParamName, animTask.DirectionParam);
				texture2.SetCustomMaterialScalarParameter(ModelBase<LifePointModel>.Instance.ParamName, animTask.DirectionParam);
				if (this.UiViewSequence.HasSequenceNameInPlaying("Change"))
				{
					this.UiViewSequence.ReplaySequence("Change");
				}
				else
				{
					this.UiViewSequence.PlaySequence("Change", false, new float?(animTask.PlayRate));
				}
			}
			this.ColorExpressed = animTask.Color;
			float[] array;
			if (!ModelBase<LifePointModel>.Instance.AudioMap.TryGetValue(animTask.Order, out array))
			{
				array = new float[2];
			}
			array[0] = array[0] + 1f;
			array[1] = animTask.PlayRate;
			ModelBase<LifePointModel>.Instance.AudioMap[animTask.Order] = array;
		}

		// Token: 0x04025F52 RID: 155474
		public Deque<AnimTask> AnimTask_ = new Deque<AnimTask>(4);

		// Token: 0x04025F53 RID: 155475
		public EPieceColorType ColorExpressed;

		// Token: 0x04025F54 RID: 155476
		public bool IsBlock;

		// Token: 0x04025F55 RID: 155477
		[Nullable(2)]
		private UiBehaviorLevelSequence UiViewSequence;

		// Token: 0x04025F56 RID: 155478
		public int X;

		// Token: 0x04025F57 RID: 155479
		public int Y;

		// Token: 0x04025F58 RID: 155480
		public EPieceColorType Color;

		// Token: 0x04025F59 RID: 155481
		public Action<int, int> Callback;
	}
}
