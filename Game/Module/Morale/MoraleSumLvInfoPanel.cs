using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005720 RID: 22304
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleSumLvInfoPanel : UiPanelBase
	{
		// Token: 0x06038C43 RID: 232515 RVA: 0x00E5FAF4 File Offset: 0x00E5DCF4
		public UniTask Init(UUIItem item)
		{
			MoraleSumLvInfoPanel.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleSumLvInfoPanel.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C44 RID: 232516 RVA: 0x00E5FB40 File Offset: 0x00E5DD40
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnBtnBuffSum))
			};
		}

		// Token: 0x06038C45 RID: 232517 RVA: 0x00E5FBD4 File Offset: 0x00E5DDD4
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleSumLvInfoPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleSumLvInfoPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038C46 RID: 232518 RVA: 0x00E5FC17 File Offset: 0x00E5DE17
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06038C47 RID: 232519 RVA: 0x00E5FC19 File Offset: 0x00E5DE19
		private void OnBtnBuffSum()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleBuffView, null, null);
		}

		// Token: 0x06038C48 RID: 232520 RVA: 0x00E5FC2C File Offset: 0x00E5DE2C
		public void UpdateData()
		{
			MoraleModel instance = ModelBase<MoraleModel>.Instance;
			bool? flag = (instance != null) ? new bool?(instance.IsMoraleGameOver()) : null;
			this.SetActive(!flag.GetValueOrDefault());
			if (flag.GetValueOrDefault())
			{
				return;
			}
			this.ItemMoraleLv.UpdateData();
			this.ItemUnbreakableLv.UpdateData();
			this.UpdateRedDot();
		}

		// Token: 0x06038C49 RID: 232521 RVA: 0x00E5FC90 File Offset: 0x00E5DE90
		public void UpdateRedDot()
		{
			bool uiactive = ModelBase<MoraleModel>.Instance.RedDotAreaBuff();
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x04020560 RID: 132448
		public MoraleLvInfoItem ItemMoraleLv;

		// Token: 0x04020561 RID: 132449
		public MoraleUnbreakableLvInfoItem ItemUnbreakableLv;

		// Token: 0x0200B7D1 RID: 47057
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038DC0 RID: 232896
			public const int ItemMoraleLv = 0;

			// Token: 0x04038DC1 RID: 232897
			public const int ItemUnbreakableLv = 1;

			// Token: 0x04038DC2 RID: 232898
			public const int BtnBuffSum = 2;

			// Token: 0x04038DC3 RID: 232899
			public const int ItemBuffSumRedDot = 3;
		}
	}
}
