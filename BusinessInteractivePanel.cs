using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013CE RID: 5070
[NullableContext(1)]
[Nullable(0)]
public class BusinessInteractivePanel : UiPanelBase
{
	// Token: 0x06008C1A RID: 35866 RVA: 0x0024DC68 File Offset: 0x0024BE68
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06008C1B RID: 35867 RVA: 0x0024DCF0 File Offset: 0x0024BEF0
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessInteractivePanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessInteractivePanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008C1C RID: 35868 RVA: 0x0024DD34 File Offset: 0x0024BF34
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		BusinessInteractivePanel.<OnBeforeShowAsyncImplement>d__9 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<BusinessInteractivePanel.<OnBeforeShowAsyncImplement>d__9>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008C1D RID: 35869 RVA: 0x0024DD78 File Offset: 0x0024BF78
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		UUIItem guideUiItem = base.GetGuideUiItem("1");
		if (guideUiItem != null)
		{
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}
		return null;
	}

	// Token: 0x06008C1E RID: 35870 RVA: 0x0024DDA4 File Offset: 0x0024BFA4
	private void OnInteractiveToggle(RoleDevelopCurve data)
	{
		if (ModelBase<MoonChasingModel>.Instance.GetWishValue() < data.WishConsume)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingRoleCostNotEnough);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<MoonChasingController>.Instance.OpenBusinessMainView();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<MoonChasingController>.Instance.RoleTrainRequest(this.RoleId, data.TrainType);
	}

	// Token: 0x06008C1F RID: 35871 RVA: 0x0024DE1E File Offset: 0x0024C01E
	private BusinessInteractivePanel.InteractiveItem InitInteractiveItem()
	{
		BusinessInteractivePanel.InteractiveItem interactiveItem = new BusinessInteractivePanel.InteractiveItem();
		interactiveItem.SetButtonFunction(new Action<RoleDevelopCurve>(this.OnInteractiveToggle));
		return interactiveItem;
	}

	// Token: 0x06008C20 RID: 35872 RVA: 0x0024DE37 File Offset: 0x0024C037
	private CharacterItem InitCharacterItem()
	{
		return new CharacterItem();
	}

	// Token: 0x06008C21 RID: 35873 RVA: 0x0024DE3E File Offset: 0x0024C03E
	public void RegisterViewController(BusinessHelperViewController vc)
	{
		this.Vc = vc;
	}

	// Token: 0x06008C22 RID: 35874 RVA: 0x0024DE48 File Offset: 0x0024C048
	public UniTask Refresh()
	{
		BusinessInteractivePanel.<Refresh>d__15 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<BusinessInteractivePanel.<Refresh>d__15>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x04004149 RID: 16713
	protected int RoleId;

	// Token: 0x0400414A RID: 16714
	protected CharacterListModule<CharacterItem> CharacterListModule;

	// Token: 0x0400414B RID: 16715
	protected GenericLayout<BusinessInteractivePanel.InteractiveItem, RoleDevelopCurve> InteractiveLayout;

	// Token: 0x0400414C RID: 16716
	[Nullable(2)]
	private BusinessHelperViewController Vc;

	// Token: 0x020077AC RID: 30636
	[NullableContext(0)]
	private static class EInteractiveItem
	{
		// Token: 0x0402930B RID: 168715
		public const int Button = 0;

		// Token: 0x0402930C RID: 168716
		public const int Icon = 1;

		// Token: 0x0402930D RID: 168717
		public const int IconTransition = 2;

		// Token: 0x0402930E RID: 168718
		public const int Content = 3;

		// Token: 0x0402930F RID: 168719
		public const int CostItem = 4;
	}

	// Token: 0x020077AD RID: 30637
	[Nullable(0)]
	protected class InteractiveItem : GridProxyAbstract<RoleDevelopCurve>
	{
		// Token: 0x060473D9 RID: 291801 RVA: 0x012F3B88 File Offset: 0x012F1D88
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITextureTransitionComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnButton))
			};
		}

		// Token: 0x060473DA RID: 291802 RVA: 0x012F3C34 File Offset: 0x012F1E34
		protected override UniTask OnBeforeStartAsync()
		{
			BusinessInteractivePanel.InteractiveItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessInteractivePanel.InteractiveItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060473DB RID: 291803 RVA: 0x012F3C77 File Offset: 0x012F1E77
		private void OnButton()
		{
			Action<RoleDevelopCurve> buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction(this.Data);
		}

		// Token: 0x060473DC RID: 291804 RVA: 0x012F3C90 File Offset: 0x012F1E90
		public override void Refresh(RoleDevelopCurve data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TrainContent, Array.Empty<object>());
			int wishItemId = ConfigBase<BusinessConfig>.Instance.GetWishItemId();
			this.CostItem.UpdateItem(wishItemId, data.WishConsume);
			this.CostItem.RefreshCountEnableState();
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(true);
			}
			base.SetTextureByPath(ConfigBase<BusinessConfig>.Instance.GetRoleDevelopTypeById(data.TrainType).Icon, base.GetTexture(1), null, delegate(bool _)
			{
				base.GetUiTextureTransitionComponent(2).SetAllStateTexture(base.GetTexture(1).GetTexture());
			});
		}

		// Token: 0x060473DD RID: 291805 RVA: 0x012F3D38 File Offset: 0x012F1F38
		public void SetButtonFunction(Action<RoleDevelopCurve> callback)
		{
			this.ButtonFunction = callback;
		}

		// Token: 0x04029310 RID: 168720
		[Nullable(2)]
		private Action<RoleDevelopCurve> ButtonFunction;

		// Token: 0x04029311 RID: 168721
		private RoleDevelopCurve Data;

		// Token: 0x04029312 RID: 168722
		private CommonCostItem CostItem;
	}

	// Token: 0x020077AE RID: 30638
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029313 RID: 168723
		public const int Name = 0;

		// Token: 0x04029314 RID: 168724
		public const int CharacterListItem = 1;

		// Token: 0x04029315 RID: 168725
		public const int Level = 2;

		// Token: 0x04029316 RID: 168726
		public const int InteractiveLayout = 3;

		// Token: 0x04029317 RID: 168727
		public const int InteractiveItem = 4;
	}
}
