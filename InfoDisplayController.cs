using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;

// Token: 0x02001FF4 RID: 8180
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class InfoDisplayController : ControllerBase<InfoDisplayController>
{
	// Token: 0x0600F70D RID: 63245 RVA: 0x00439ED8 File Offset: 0x004380D8
	public bool OpenInfoDisplay(int reactId, TOpenViewCallBack finishCallback = null, object param = null, bool inPlot = false, ELayerType? layerType = null)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfoDisplayTypeOneView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfoDisplayTypeTwoView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfoDisplayTypeThreeView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfoDisplayTypeFourNewView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InfoDisplayTypeFiveView))
		{
			return false;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("infodisplay_use_item_cd");
		if (this.LastOpenTime != 0.0)
		{
			double num = Singleton<Time>.Instance.Now - this.LastOpenTime;
			if (intConfig != null && num <= (double)(intConfig.Value * 1000))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
				return false;
			}
		}
		ModelBase<InfoDisplayModel>.Instance.ClearGroupInfo();
		ModelBase<InfoDisplayModel>.Instance.SetCurrentOpenInformationId(reactId);
		int infoDisplayType = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayType(reactId);
		EUiViewName? infoDisplayViewName = this.GetInfoDisplayViewName(infoDisplayType);
		if (infoDisplayViewName != null)
		{
			if (inPlot)
			{
				Singleton<UiManager>.Instance.OpenViewByPlot(infoDisplayViewName.Value, param, finishCallback);
			}
			else if (layerType != null)
			{
				Singleton<UiManager>.Instance.OpenViewWithLayer(infoDisplayViewName.Value, layerType.Value, null, finishCallback);
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(infoDisplayViewName.Value, null, finishCallback);
			}
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		return true;
	}

	// Token: 0x0600F70E RID: 63246 RVA: 0x0043A030 File Offset: 0x00438230
	private EUiViewName? GetInfoDisplayViewName(int type)
	{
		if (type == 1)
		{
			return new EUiViewName?(EUiViewName.InfoDisplayTypeOneView);
		}
		if (type == 2)
		{
			return new EUiViewName?(EUiViewName.InfoDisplayTypeTwoView);
		}
		if (type == 3)
		{
			return new EUiViewName?(EUiViewName.InfoDisplayTypeThreeView);
		}
		if (type == 4)
		{
			return new EUiViewName?(EUiViewName.InfoDisplayTypeFourNewView);
		}
		if (type == 5)
		{
			return new EUiViewName?(EUiViewName.InfoDisplayTypeFiveView);
		}
		return null;
	}

	// Token: 0x0600F70F RID: 63247 RVA: 0x0043A094 File Offset: 0x00438294
	public unsafe bool OpenInfoDisplayGroup(int groupId, TOpenViewCallBack finishCallback = null, object param = null, bool inPlot = false, ELayerType? layerType = null)
	{
		InfoDisplayGroup? config = ConfigInfoDisplayGroupById.GetConfig(groupId, true);
		if (config == null || config.Value.InfoListLength == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InfoDisplay;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "信息展示组配置不存在或信息列表为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("groupId", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < config.Value.InfoListLength; i++)
		{
			list.Add(config.Value.InfoList(i));
		}
		int infoDisplayType = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayType(list[0]);
		if (infoDisplayType != 1 && infoDisplayType != 3)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.InfoDisplay;
			ELogAuthor author2 = ELogAuthor.HYF;
			string message2 = "信息展示组配置错误，仅支持类型1和3";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("groupId", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", infoDisplayType);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		foreach (int num in list)
		{
			int infoDisplayType2 = ConfigBase<InfoDisplayModuleConfig>.Instance.GetInfoDisplayType(num);
			if (infoDisplayType2 != infoDisplayType)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.InfoDisplay;
				ELogAuthor author3 = ELogAuthor.HYF;
				string message3 = "信息展示组配置错误，组内信息类型不一致";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("groupId", groupId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("infoId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("type", infoDisplayType2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("groupType", infoDisplayType);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				return false;
			}
		}
		bool flag = this.OpenInfoDisplay(list[0], finishCallback, param, inPlot, layerType);
		if (flag)
		{
			ModelBase<InfoDisplayModel>.Instance.SetGroupInfo(list);
		}
		return flag;
	}

	// Token: 0x0600F710 RID: 63248 RVA: 0x0043A2CC File Offset: 0x004384CC
	public void OpenInfoDisplayImgView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InfoDisplayImgView, null, null);
	}

	// Token: 0x0600F711 RID: 63249 RVA: 0x0043A2DF File Offset: 0x004384DF
	public void OpenInfoDisplayAttachmentBigImgView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InfoDisplayAttachmentBigImgView, null, null);
	}

	// Token: 0x0600F712 RID: 63250 RVA: 0x0043A2F2 File Offset: 0x004384F2
	protected override bool OnInit()
	{
		this.OnAddEvents();
		return true;
	}

	// Token: 0x0600F713 RID: 63251 RVA: 0x0043A2FB File Offset: 0x004384FB
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x0600F714 RID: 63252 RVA: 0x0043A304 File Offset: 0x00438504
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
	}

	// Token: 0x0600F715 RID: 63253 RVA: 0x0043A322 File Offset: 0x00438522
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
	}

	// Token: 0x0600F716 RID: 63254 RVA: 0x0043A340 File Offset: 0x00438540
	private void OnItemUse(int configId, int useCount)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(configId);
		int num;
		if (itemConfig != null && itemConfig.Value.Parameters().Count > 0 && itemConfig.Value.Parameters().TryGetValue(12, out num) && num != 0)
		{
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplay(num, null, null, false, null);
		}
	}

	// Token: 0x0600F717 RID: 63255 RVA: 0x0043A3B0 File Offset: 0x004385B0
	public void RequestReadDisplayInfo(int displayId)
	{
		ReadDisplayInfoRequest readDisplayInfoRequest = ReadDisplayInfoRequest.Create();
		readDisplayInfoRequest.DisplayId = displayId;
		Singleton<Net>.Instance.Call<ReadDisplayInfoResponse>(ERequestMessageId.ReadDisplayInfoRequest, readDisplayInfoRequest, delegate(ReadDisplayInfoResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22913, null, true, true);
			}
		}, 0);
	}

	// Token: 0x04007752 RID: 30546
	private double LastOpenTime;

	// Token: 0x04007753 RID: 30547
	public const int INFO_DISPLAY_ITEM_TYPE = 12;

	// Token: 0x02008373 RID: 33651
	[NullableContext(0)]
	public enum EInfoDisplayViewEnum
	{
		// Token: 0x0402C95D RID: 182621
		TypeOne = 1,
		// Token: 0x0402C95E RID: 182622
		TypeTwo,
		// Token: 0x0402C95F RID: 182623
		TypeThree,
		// Token: 0x0402C960 RID: 182624
		TypeFour,
		// Token: 0x0402C961 RID: 182625
		TypeFive
	}
}
