using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005796 RID: 22422
	[NullableContext(2)]
	[Nullable(0)]
	public class ToolWindowView : UiViewBase
	{
		// Token: 0x06039060 RID: 233568 RVA: 0x00E73081 File Offset: 0x00E71281
		[NullableContext(1)]
		public ToolWindowView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039061 RID: 233569 RVA: 0x00E7308C File Offset: 0x00E7128C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06039062 RID: 233570 RVA: 0x00E73114 File Offset: 0x00E71314
		protected override void OnStart()
		{
			base.GetText(0).ShowTextNew("PrefabTextItem_HotfixTool_Text");
			this.ButtonFixPatch = new ToolWindowButtonItem(base.GetItem(1));
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_HotfixTool_clear_Text", null);
			this.ButtonFixPatch.SetText(localTextNew);
			this.ButtonFixPatch.BindCallback(new Action(this.FixPatch));
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Tool_Clean");
			this.ButtonFixPatch.RefreshIcon(resourcePath, delegate(bool result)
			{
				this.ButtonFixPatch.SetIconVisible(true);
			});
			this.ButtonLogUpload = new ToolWindowButtonItem(base.GetItem(2));
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_HotfixTool_upload_Text", null);
			this.ButtonLogUpload.SetText(localTextNew2);
			this.ButtonLogUpload.BindCallback(new Action(this.OpenLogUpload));
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Tool_Upload");
			this.ButtonLogUpload.RefreshIcon(resourcePath2, delegate(bool result)
			{
				this.ButtonLogUpload.SetIconVisible(true);
			});
			this.ButtonNetworkDetection = new ToolWindowButtonItem(base.GetItem(3));
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("NetworkDetection_Title");
			this.ButtonNetworkDetection.SetText(multiTextByKey);
			this.ButtonNetworkDetection.BindCallback(new Action(this.NetworkDetection));
			string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconNet");
			this.ButtonNetworkDetection.RefreshIcon(resourcePath3, delegate(bool result)
			{
				this.ButtonNetworkDetection.SetIconVisible(true);
			});
			MenuConfig? menuConfigByFunctionId = ConfigBase<MenuBaseConfig>.Instance.GetMenuConfigByFunctionId(20360);
			bool item = Singleton<GameSettingsManager>.Instance.CheckConfigValidByCheckList(menuConfigByFunctionId.Value).Item1;
			base.GetItem(4).SetUIActive(item);
			if (item)
			{
				this.ButtonVulkan = new ToolWindowButtonItem(base.GetItem(4));
				string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("ToolsImageSet_Text");
				this.ButtonVulkan.SetText(multiTextByKey2);
				this.ButtonVulkan.BindCallback(new Action(this.OnClickVulkan));
				string resourcePath4 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconVulkan");
				this.ButtonVulkan.RefreshIcon(resourcePath4, delegate(bool result)
				{
					this.ButtonVulkan.SetIconVisible(true);
				});
			}
		}

		// Token: 0x06039063 RID: 233571 RVA: 0x00E73321 File Offset: 0x00E71521
		private void OpenLogUpload()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.LogUploadView, null, null);
		}

		// Token: 0x06039064 RID: 233572 RVA: 0x00E73334 File Offset: 0x00E71534
		private void FixPatch()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ClearHotPatchConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(ToolWindowView.<FixPatch>g__ConfirmCallback|8_0));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06039065 RID: 233573 RVA: 0x00E73370 File Offset: 0x00E71570
		private void NetworkDetection()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.NetworkDetectionView, null, null);
		}

		// Token: 0x06039066 RID: 233574 RVA: 0x00E73383 File Offset: 0x00E71583
		private void OnClickVulkan()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VulkanSetView, null, null);
		}

		// Token: 0x0603906B RID: 233579 RVA: 0x00E733D0 File Offset: 0x00E715D0
		[CompilerGenerated]
		internal static void <FixPatch>g__ConfirmCallback|8_0()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PatchCleanProcessing);
			confirmBoxDataNew.SetAfterShowFunction(delegate
			{
				Singleton<HotPatch>.Instance.ClearPatch();
			});
			confirmBoxDataNew.SetCloseFunction(delegate
			{
				Singleton<HotPatch>.Instance.ClearPatch();
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x04020782 RID: 132994
		private ToolWindowButtonItem ButtonLogUpload;

		// Token: 0x04020783 RID: 132995
		private ToolWindowButtonItem ButtonFixPatch;

		// Token: 0x04020784 RID: 132996
		private ToolWindowButtonItem ButtonNetworkDetection;

		// Token: 0x04020785 RID: 132997
		private ToolWindowButtonItem ButtonVulkan;
	}
}
