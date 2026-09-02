using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C56 RID: 23638
	public class InfrastructureSettleView : UiViewBase
	{
		// Token: 0x0603BB83 RID: 244611 RVA: 0x00F20C71 File Offset: 0x00F1EE71
		[NullableContext(1)]
		public InfrastructureSettleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603BB84 RID: 244612 RVA: 0x00F20C88 File Offset: 0x00F1EE88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BB85 RID: 244613 RVA: 0x00F20D9C File Offset: 0x00F1EF9C
		protected override UniTask OnBeforeStartAsync()
		{
			InfrastructureSettleView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrastructureSettleView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB86 RID: 244614 RVA: 0x00F20DE0 File Offset: 0x00F1EFE0
		protected override void OnStart()
		{
			base.GetItem(13).SetUIActive(true);
			base.GetText(14).SetUIActive(true);
			base.SetTextureByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_Logo_Activity_1_UI"), base.GetTexture(2), null, null);
			base.GetText(10).SetColor(FColor.FromHex("#F0D33F"));
			base.GetText(11).SetColor(FColor.FromHex("#ECE5D8"));
			base.GetText(14).SetColor(FColor.FromHex("#ECE5D8"));
			base.GetText(1).ShowTextNew("Build_CompleteTitle");
			(base.GetText(1).GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline).SetOutlineColor(FColor.FromHex("#C48B29"));
			InfrastructureDefine.IInfrSettleViewOpenParam infrSettleViewOpenParam = this.OpenParam as InfrastructureDefine.IInfrSettleViewOpenParam;
			if (infrSettleViewOpenParam.DeliveryType == ActionInfrastructureItemDeliveryType.Observatory)
			{
				InfrLevel? levelConfigById = ConfigBase<InfrastructureConfig>.Instance.GetLevelConfigById(ModelBase<InfrastructureModel>.Instance.FireLevel);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), levelConfigById.Value.BuildSuccessDes, Array.Empty<object>());
			}
			else
			{
				InfrRoadBuild? roadConfigById = ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(infrSettleViewOpenParam.RoadId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Build_CompleteDes", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(roadConfigById.Value.Name, Array.Empty<object>())));
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Build_CompleteTime", Array.Empty<object>());
			base.GetText(10).SetText(Singleton<TimeUtil>.Instance.DateFormatString(Singleton<Time>.Instance.ServerTimeStamp / 1000.0), true);
			this.RefreshButton();
		}

		// Token: 0x0603BB87 RID: 244615 RVA: 0x00F20F9C File Offset: 0x00F1F19C
		protected override void OnAfterPlayStartSequence()
		{
			this.UiViewSequence.PlaySequence("Success", true, null);
		}

		// Token: 0x0603BB88 RID: 244616 RVA: 0x00F20FC4 File Offset: 0x00F1F1C4
		private UniTask InitButtonAsync()
		{
			InfrastructureSettleView.<InitButtonAsync>d__7 <InitButtonAsync>d__;
			<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonAsync>d__.<>4__this = this;
			<InitButtonAsync>d__.<>1__state = -1;
			<InitButtonAsync>d__.<>t__builder.Start<InfrastructureSettleView.<InitButtonAsync>d__7>(ref <InitButtonAsync>d__);
			return <InitButtonAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BB89 RID: 244617 RVA: 0x00F21008 File Offset: 0x00F1F208
		private void RefreshButton()
		{
			base.GetItem(5).SetUIActive(true);
			this.Button.SetUiActive(true);
			this.Button.SetBtnText("Leave", Array.Empty<string>());
			this.Button.HideFloatText();
			this.Button.SetOnClickEvent(new Action(this.OnClickBtnLeave));
			this.Button.SetOnClickLeftEvent(new Action(this.OnClickBtnLeaveLeft));
		}

		// Token: 0x0603BB8A RID: 244618 RVA: 0x00F2107C File Offset: 0x00F1F27C
		private void OnClickBtnLeave()
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}

		// Token: 0x0603BB8B RID: 244619 RVA: 0x00F21089 File Offset: 0x00F1F289
		private void OnClickBtnLeaveLeft()
		{
			base.CloseMe(null);
		}

		// Token: 0x04021929 RID: 137513
		[Nullable(1)]
		protected InfrastructureSettleViewButton Button = new InfrastructureSettleViewButton();

		// Token: 0x0200BCD0 RID: 48336
		private class EComponents
		{
			// Token: 0x0403A2BA RID: 238266
			public const int TxtTitle = 1;

			// Token: 0x0403A2BB RID: 238267
			public const int TextureIcon = 2;

			// Token: 0x0403A2BC RID: 238268
			public const int ButtonHorizontalItem = 4;

			// Token: 0x0403A2BD RID: 238269
			public const int PanelButtonItem = 5;

			// Token: 0x0403A2BE RID: 238270
			public const int TextTime = 10;

			// Token: 0x0403A2BF RID: 238271
			public const int TextPassTime = 11;

			// Token: 0x0403A2C0 RID: 238272
			public const int PanelPassTime = 13;

			// Token: 0x0403A2C1 RID: 238273
			public const int TextMidText = 14;
		}
	}
}
