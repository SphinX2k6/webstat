using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.InputView.Model;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Common.InputView.Controller
{
	// Token: 0x02005E81 RID: 24193
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CommonInputViewController : UiControllerBase<CommonInputViewController>
	{
		// Token: 0x0603CD89 RID: 249225 RVA: 0x00F7197C File Offset: 0x00F6FB7C
		public void OpenSetRoleNameInputView()
		{
			string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("SetName");
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew(textContentIdById, Array.Empty<object>()),
				ConfirmFunc = new Func<string, UniTask<Aki.Protocol.ErrorCode>>(ControllerBase<PersonalController>.Instance.RequestModifyName),
				InputText = playerName,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_3848209236_Text", null),
				IsCheckNone = true,
				NeedFunctionButton = false,
				BottomTipsText = string.Empty,
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonModifyNameInputView, param, null);
		}

		// Token: 0x0603CD8A RID: 249226 RVA: 0x00F71A20 File Offset: 0x00F6FC20
		public void OpenSetPlayerRemarkNameInputView()
		{
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c.<<OpenSetPlayerRemarkNameInputView>b__1_0>d <<OpenSetPlayerRemarkNameInputView>b__1_0>d;
				<<OpenSetPlayerRemarkNameInputView>b__1_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenSetPlayerRemarkNameInputView>b__1_0>d.input = input;
				<<OpenSetPlayerRemarkNameInputView>b__1_0>d.<>1__state = -1;
				<<OpenSetPlayerRemarkNameInputView>b__1_0>d.<>t__builder.Start<CommonInputViewController.<>c.<<OpenSetPlayerRemarkNameInputView>b__1_0>d>(ref <<OpenSetPlayerRemarkNameInputView>b__1_0>d);
				return <<OpenSetPlayerRemarkNameInputView>b__1_0>d.<>t__builder.Task;
			};
			FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
			string text = (selectedPlayerOrItemInstance != null) ? selectedPlayerOrItemInstance.FriendRemark : null;
			if (StringUtils.IsEmpty(text))
			{
				FriendData selectedPlayerOrItemInstance2 = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
				text = ((selectedPlayerOrItemInstance2 != null) ? selectedPlayerOrItemInstance2.PlayerName : null);
			}
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("SetRemark");
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew(textContentIdById, Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				InputText = text,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_3848209236_Text", null),
				IsCheckNone = false,
				NeedFunctionButton = false,
				BottomTipsText = string.Empty,
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSingleInputView, param, null);
		}

		// Token: 0x0603CD8B RID: 249227 RVA: 0x00F71B28 File Offset: 0x00F6FD28
		public void OpenPersonalSignInputView()
		{
			string signature = ModelBase<PersonalModel>.Instance.GetSignature();
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("SetSign");
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew(textContentIdById, Array.Empty<object>()),
				ConfirmFunc = new Func<string, UniTask<Aki.Protocol.ErrorCode>>(ControllerBase<PersonalController>.Instance.RequestModifySignature),
				DefaultText = ConfigBase<TextConfig>.Instance.GetTextById("ComplianceWithTheLaw"),
				InputText = signature,
				IsCheckNone = false,
				NeedFunctionButton = false,
				BottomTipsText = string.Empty,
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonMultiInputView, param, null);
		}

		// Token: 0x0603CD8C RID: 249228 RVA: 0x00F71BD0 File Offset: 0x00F6FDD0
		public void OpenCdKeyInputView()
		{
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c.<<OpenCdKeyInputView>b__3_0>d <<OpenCdKeyInputView>b__3_0>d;
				<<OpenCdKeyInputView>b__3_0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenCdKeyInputView>b__3_0>d.input = input;
				<<OpenCdKeyInputView>b__3_0>d.<>1__state = -1;
				<<OpenCdKeyInputView>b__3_0>d.<>t__builder.Start<CommonInputViewController.<>c.<<OpenCdKeyInputView>b__3_0>d>(ref <<OpenCdKeyInputView>b__3_0>d);
				return <<OpenCdKeyInputView>b__3_0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("PrefabTextItem_CDKey_Title", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				DefaultText = (ConfigMultiTextLang.GetLocalTextNew("CDKey_InputEmpty", null) ?? string.Empty),
				InputText = string.Empty,
				IsCheckNone = true,
				NeedFunctionButton = true,
				BottomTipsText = string.Empty,
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CdKeyInputView, param, null);
		}

		// Token: 0x0603CD8D RID: 249229 RVA: 0x00F71C7C File Offset: 0x00F6FE7C
		public void OpenSetVisionEquipGroupName(string bottomText, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack, string startInputText = "")
		{
			CommonInputViewController.<>c__DisplayClass4_0 CS$<>8__locals1 = new CommonInputViewController.<>c__DisplayClass4_0();
			CS$<>8__locals1.callBack = callBack;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c__DisplayClass4_0.<<OpenSetVisionEquipGroupName>b__0>d <<OpenSetVisionEquipGroupName>b__0>d;
				<<OpenSetVisionEquipGroupName>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenSetVisionEquipGroupName>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenSetVisionEquipGroupName>b__0>d.input = input;
				<<OpenSetVisionEquipGroupName>b__0>d.<>1__state = -1;
				<<OpenSetVisionEquipGroupName>b__0>d.<>t__builder.Start<CommonInputViewController.<>c__DisplayClass4_0.<<OpenSetVisionEquipGroupName>b__0>d>(ref <<OpenSetVisionEquipGroupName>b__0>d);
				return <<OpenSetVisionEquipGroupName>b__0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("VisionAssembleSaveTips", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				InputText = startInputText,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("VisionAssembleInputTips", null),
				IsCheckNone = true,
				NeedFunctionButton = false,
				BottomTipsText = bottomText,
				BottomTipsColor = "000000",
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionAssembleInputView, param, null);
		}

		// Token: 0x0603CD8E RID: 249230 RVA: 0x00F71D18 File Offset: 0x00F6FF18
		public void OpenChangeVisionEquipGroupName(string bottomText, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack)
		{
			CommonInputViewController.<>c__DisplayClass5_0 CS$<>8__locals1 = new CommonInputViewController.<>c__DisplayClass5_0();
			CS$<>8__locals1.callBack = callBack;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c__DisplayClass5_0.<<OpenChangeVisionEquipGroupName>b__0>d <<OpenChangeVisionEquipGroupName>b__0>d;
				<<OpenChangeVisionEquipGroupName>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenChangeVisionEquipGroupName>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenChangeVisionEquipGroupName>b__0>d.input = input;
				<<OpenChangeVisionEquipGroupName>b__0>d.<>1__state = -1;
				<<OpenChangeVisionEquipGroupName>b__0>d.<>t__builder.Start<CommonInputViewController.<>c__DisplayClass5_0.<<OpenChangeVisionEquipGroupName>b__0>d>(ref <<OpenChangeVisionEquipGroupName>b__0>d);
				return <<OpenChangeVisionEquipGroupName>b__0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("VisionAssembleChangeNameTips", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				InputText = string.Empty,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("VisionAssembleInputTips", null),
				IsCheckNone = false,
				NeedFunctionButton = false,
				BottomTipsText = bottomText,
				BottomTipsColor = "000000"
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonSingleInputView, param, null);
		}

		// Token: 0x0603CD8F RID: 249231 RVA: 0x00F71DAC File Offset: 0x00F6FFAC
		public void OpenSetPhantomArenaDeckName(string bottomText, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack, string startInputText = "")
		{
			CommonInputViewController.<>c__DisplayClass6_0 CS$<>8__locals1 = new CommonInputViewController.<>c__DisplayClass6_0();
			CS$<>8__locals1.callBack = callBack;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c__DisplayClass6_0.<<OpenSetPhantomArenaDeckName>b__0>d <<OpenSetPhantomArenaDeckName>b__0>d;
				<<OpenSetPhantomArenaDeckName>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenSetPhantomArenaDeckName>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenSetPhantomArenaDeckName>b__0>d.input = input;
				<<OpenSetPhantomArenaDeckName>b__0>d.<>1__state = -1;
				<<OpenSetPhantomArenaDeckName>b__0>d.<>t__builder.Start<CommonInputViewController.<>c__DisplayClass6_0.<<OpenSetPhantomArenaDeckName>b__0>d>(ref <<OpenSetPhantomArenaDeckName>b__0>d);
				return <<OpenSetPhantomArenaDeckName>b__0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("PhantomBattle_1076", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				InputText = startInputText,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("PhantomBattle_1077", null),
				IsCheckNone = true,
				NeedFunctionButton = false,
				BottomTipsText = bottomText,
				BottomTipsColor = "000000",
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckRenameInputView, param, null);
		}

		// Token: 0x0603CD90 RID: 249232 RVA: 0x00F71E48 File Offset: 0x00F70048
		public void OpenSetPhantomManageConfigName(string inputText, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack, string bottomText = "")
		{
			CommonInputViewController.<>c__DisplayClass7_0 CS$<>8__locals1 = new CommonInputViewController.<>c__DisplayClass7_0();
			CS$<>8__locals1.callBack = callBack;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c__DisplayClass7_0.<<OpenSetPhantomManageConfigName>b__0>d <<OpenSetPhantomManageConfigName>b__0>d;
				<<OpenSetPhantomManageConfigName>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenSetPhantomManageConfigName>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenSetPhantomManageConfigName>b__0>d.input = input;
				<<OpenSetPhantomManageConfigName>b__0>d.<>1__state = -1;
				<<OpenSetPhantomManageConfigName>b__0>d.<>t__builder.Start<CommonInputViewController.<>c__DisplayClass7_0.<<OpenSetPhantomManageConfigName>b__0>d>(ref <<OpenSetPhantomManageConfigName>b__0>d);
				return <<OpenSetPhantomManageConfigName>b__0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("PhantomProject_Name", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				InputText = inputText,
				DefaultText = ConfigMultiTextLang.GetLocalTextNew("PhantomProject_Tips01", null),
				IsCheckNone = true,
				NeedFunctionButton = false,
				BottomTipsText = bottomText,
				BottomTipsColor = "000000",
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManageConfigRenameInputView, param, null);
		}

		// Token: 0x0603CD91 RID: 249233 RVA: 0x00F71EE4 File Offset: 0x00F700E4
		public void OpenMotorcycleDiyNameInputView([Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack, string initialInputText = "")
		{
			CommonInputViewController.<>c__DisplayClass8_0 CS$<>8__locals1 = new CommonInputViewController.<>c__DisplayClass8_0();
			CS$<>8__locals1.callBack = callBack;
			Func<string, UniTask<Aki.Protocol.ErrorCode>> confirmFunc = delegate([Nullable(1)] string input)
			{
				CommonInputViewController.<>c__DisplayClass8_0.<<OpenMotorcycleDiyNameInputView>b__0>d <<OpenMotorcycleDiyNameInputView>b__0>d;
				<<OpenMotorcycleDiyNameInputView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
				<<OpenMotorcycleDiyNameInputView>b__0>d.<>4__this = CS$<>8__locals1;
				<<OpenMotorcycleDiyNameInputView>b__0>d.input = input;
				<<OpenMotorcycleDiyNameInputView>b__0>d.<>1__state = -1;
				<<OpenMotorcycleDiyNameInputView>b__0>d.<>t__builder.Start<CommonInputViewController.<>c__DisplayClass8_0.<<OpenMotorcycleDiyNameInputView>b__0>d>(ref <<OpenMotorcycleDiyNameInputView>b__0>d);
				return <<OpenMotorcycleDiyNameInputView>b__0>d.<>t__builder.Task;
			};
			ICommonInputViewData param = new CommonInputViewData
			{
				TitleTextArgs = new TableTextArgNew("DIYProjectEditName", Array.Empty<object>()),
				ConfirmFunc = confirmFunc,
				DefaultText = (ConfigMultiTextLang.GetLocalTextNew("DIYProjectDefaultName", null) ?? string.Empty),
				InputText = initialInputText,
				IsCheckNone = true,
				NeedFunctionButton = false,
				BottomTipsText = string.Empty,
				BottomTipsColor = "000000",
				NeedCheckBlank = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyNameInputView, param, null);
		}
	}
}
