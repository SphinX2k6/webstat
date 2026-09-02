using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006837 RID: 26679
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingLevelUpTips : UiTickViewBase
	{
		// Token: 0x06042835 RID: 272437 RVA: 0x011128A3 File Offset: 0x01110AA3
		public FishingLevelUpTips(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042836 RID: 272438 RVA: 0x011128B4 File Offset: 0x01110AB4
		protected unsafe override void OnRegisterComponent()
		{
			this.ExpData = (this.OpenParam as FishingLevelUpData);
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042837 RID: 272439 RVA: 0x01112994 File Offset: 0x01110B94
		protected override UniTask OnBeforeStartAsync()
		{
			FishingLevelUpTips.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingLevelUpTips.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042838 RID: 272440 RVA: 0x011129D8 File Offset: 0x01110BD8
		protected override void OnStart()
		{
			this.AddText = base.GetText(1);
			this.SpriteBar = base.GetSprite(2);
			this.Level = this.ExpData.LastLevel;
			this.CurrentExp = (float)this.ExpData.LastExp;
			this.CurrentMaxExp = this.ExpData.GetMaxExpByLevel(this.Level);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.AddText, "Fishing_Experience", new <>z__ReadOnlySingleElementList<object>(this.ExpData.AddExp));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Fishing_Level", Array.Empty<object>());
			base.GetText(0).SetText(this.Level.ToString(), true);
		}

		// Token: 0x06042839 RID: 272441 RVA: 0x01112A98 File Offset: 0x01110C98
		protected override void OnTick(float delta)
		{
			if (!this.IsTick)
			{
				return;
			}
			if (this.DeltaAddExp >= (float)this.ExpData.AddExp)
			{
				base.CloseMe(null);
				this.IsTick = false;
				return;
			}
			this.RefreshExp((float)this.ExpData.AddExp * 1f / 2000f * delta);
		}

		// Token: 0x0604283A RID: 272442 RVA: 0x01112AF4 File Offset: 0x01110CF4
		private void RefreshExp(float addExp)
		{
			this.DeltaAddExp += addExp;
			this.CurrentExp = Singleton<MathUtils>.Instance.Clamp(this.CurrentExp + addExp, this.CurrentExp, (float)this.CurrentMaxExp);
			this.SpriteBar.SetFillAmount(this.CurrentExp / (float)this.CurrentMaxExp);
			if (this.CurrentExp >= (float)this.CurrentMaxExp && this.Level < this.ExpData.CurrentLevel)
			{
				this.Level++;
				this.CurrentExp = 0f;
				this.CurrentMaxExp = this.ExpData.GetMaxExpByLevel(this.Level);
				base.GetText(0).SetText(this.Level.ToString(), true);
			}
		}

		// Token: 0x04025048 RID: 151624
		private const int TICK_TIME = 2000;

		// Token: 0x04025049 RID: 151625
		protected FishingLevelUpData ExpData;

		// Token: 0x0402504A RID: 151626
		protected int Level;

		// Token: 0x0402504B RID: 151627
		protected float CurrentExp;

		// Token: 0x0402504C RID: 151628
		protected float DeltaAddExp;

		// Token: 0x0402504D RID: 151629
		protected int CurrentMaxExp;

		// Token: 0x0402504E RID: 151630
		protected bool IsTick = true;

		// Token: 0x0402504F RID: 151631
		protected UUIText AddText;

		// Token: 0x04025050 RID: 151632
		protected UUISprite SpriteBar;

		// Token: 0x0200C879 RID: 51321
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DB41 RID: 252737
			public const int LevelNum = 0;

			// Token: 0x0403DB42 RID: 252738
			public const int AddText = 1;

			// Token: 0x0403DB43 RID: 252739
			public const int SpriteBar = 2;

			// Token: 0x0403DB44 RID: 252740
			public const int Title = 3;

			// Token: 0x0403DB45 RID: 252741
			public const int Texture = 4;
		}
	}
}
