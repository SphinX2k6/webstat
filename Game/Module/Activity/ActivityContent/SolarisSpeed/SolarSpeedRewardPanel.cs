using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006393 RID: 25491
	[NullableContext(1)]
	[Nullable(0)]
	internal class SolarSpeedRewardPanel : UiPanelBase
	{
		// Token: 0x0604002E RID: 262190 RVA: 0x0106814C File Offset: 0x0106634C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604002F RID: 262191 RVA: 0x010681F8 File Offset: 0x010663F8
		protected override UniTask OnBeforeStartAsync()
		{
			SolarSpeedRewardPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SolarSpeedRewardPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040030 RID: 262192 RVA: 0x0106823B File Offset: 0x0106643B
		protected override void OnStart()
		{
			this.RefreshByOpenParam();
		}

		// Token: 0x06040031 RID: 262193 RVA: 0x01068244 File Offset: 0x01066444
		public void RefreshByOpenParam()
		{
			ISolarSpeedRewardPanelData solarSpeedRewardPanelData = this.OpenParam as ISolarSpeedRewardPanelData;
			this.TabLayout.RefreshByData(solarSpeedRewardPanelData.TabDataList, null, false);
			this.RewardLayout.RefreshByData(solarSpeedRewardPanelData.RewardDataList, null, false);
		}

		// Token: 0x06040032 RID: 262194 RVA: 0x01068283 File Offset: 0x01066483
		public void PlayStart(string animName)
		{
			(base.GetVerticalLayout(2).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController).Play(animName, -1, false);
		}

		// Token: 0x06040033 RID: 262195 RVA: 0x010682AD File Offset: 0x010664AD
		private SolarSpeedTabCellPanel BuildSolarSpeedTabCellPanel()
		{
			return new SolarSpeedTabCellPanel();
		}

		// Token: 0x06040034 RID: 262196 RVA: 0x010682B4 File Offset: 0x010664B4
		private SolarSpeedRewardCellPanel BuildSolarSpeedRewardCellPanel()
		{
			return new SolarSpeedRewardCellPanel();
		}

		// Token: 0x04023F0F RID: 147215
		private GenericLayout<SolarSpeedTabCellPanel, ISolarSpeedTabCellPanelData> TabLayout;

		// Token: 0x04023F10 RID: 147216
		private GenericLayout<SolarSpeedRewardCellPanel, ISolarSpeedRewardCellPanelData> RewardLayout;

		// Token: 0x0200C3F0 RID: 50160
		[NullableContext(0)]
		private class ERewardComponent
		{
			// Token: 0x0403C59F RID: 247199
			public const int TabContentLayout = 0;

			// Token: 0x0403C5A0 RID: 247200
			public const int TabCellItem = 1;

			// Token: 0x0403C5A1 RID: 247201
			public const int RewardContentLayout = 2;

			// Token: 0x0403C5A2 RID: 247202
			public const int RewardCellItem = 3;
		}
	}
}
