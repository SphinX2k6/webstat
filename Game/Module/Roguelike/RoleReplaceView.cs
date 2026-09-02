using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B6 RID: 20918
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleReplaceView : RogueSelectBaseView
	{
		// Token: 0x06035C7A RID: 220282 RVA: 0x00D86AE7 File Offset: 0x00D84CE7
		public RoleReplaceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035C7B RID: 220283 RVA: 0x00D86B18 File Offset: 0x00D84D18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C7C RID: 220284 RVA: 0x00D86C08 File Offset: 0x00D84E08
		private void ConfirmBtn(int _)
		{
			if (this.RoguelikeChooseData.RogueGainEntryList.Count <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.ZJC, "当前可选角色为0", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = this.RoguelikeChooseData.RogueGainEntryList[0];
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Role);
		}

		// Token: 0x06035C7D RID: 220285 RVA: 0x00D86C70 File Offset: 0x00D84E70
		protected override UniTask OnCreateAsync()
		{
			RoleReplaceView.<OnCreateAsync>d__9 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<RoleReplaceView.<OnCreateAsync>d__9>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C7E RID: 220286 RVA: 0x00D86CB4 File Offset: 0x00D84EB4
		protected override UniTask OnBeforeStartAsync()
		{
			RoleReplaceView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleReplaceView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C7F RID: 220287 RVA: 0x00D86CF8 File Offset: 0x00D84EF8
		protected override void OnStart()
		{
			this.UiPoolActorPrivate.UiItem.SetUIParent(base.GetHorizontalLayout(1).GetRootComponent(), false);
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			this.RoguelikeChooseData = (this.OpenParam as RoguelikeChooseData);
			this.TopPanel.CloseCallback = new Action(base.CloseMySelf);
			this.ElementPanel.SetActive(false);
			this.ButtonItem = new ButtonItem(base.GetButton(2).GetRootComponent());
			this.ButtonItem.SetFunction(new Action<int>(this.ConfirmBtn));
			this.RoleSelectItemLayout = new GenericLayout<RoleSelectItem, RogueGainEntry>(base.GetHorizontalLayout(1), this.CreateRoleSelectItem, null, false, true);
		}

		// Token: 0x06035C80 RID: 220288 RVA: 0x00D86DAA File Offset: 0x00D84FAA
		protected override void OnBeforeDestroy()
		{
			this.TopPanel.Destroy(null);
			this.ElementPanel.Destroy(null);
			base.RecycleUiPoolActor();
		}

		// Token: 0x06035C81 RID: 220289 RVA: 0x00D86DCA File Offset: 0x00D84FCA
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035C82 RID: 220290 RVA: 0x00D86DD2 File Offset: 0x00D84FD2
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06035C83 RID: 220291 RVA: 0x00D86DDC File Offset: 0x00D84FDC
		protected override void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			if (isSuccess)
			{
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				int? num = (roguelikeChooseData != null) ? new int?(roguelikeChooseData.Index) : null;
				if (bindId == num.GetValueOrDefault() & num != null)
				{
					Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.RogueRoleSelectResultView, new RogueSelectResult(newRogueGainEntry, oldRogueGainEntry, null, false), null, true);
					return;
				}
			}
		}

		// Token: 0x06035C84 RID: 220292 RVA: 0x00D86E47 File Offset: 0x00D85047
		private void Refresh()
		{
			this.RefreshPhantomSelectItemList();
			this.RefreshTopPanel();
			this.RefreshElementPanel();
			this.RefreshBtnText();
			this.RefreshOldNewText();
		}

		// Token: 0x06035C85 RID: 220293 RVA: 0x00D86E68 File Offset: 0x00D85068
		protected void RefreshTopPanel()
		{
			this.TopPanel.RefreshTitle("RoguelikeView_3_Text");
			List<RogueGainEntry> rogueGainEntryList = this.GetRogueGainEntryList();
			RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(rogueGainEntryList[0].ConfigId);
			RogueCharacter? rogueCharacterConfig2 = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(rogueGainEntryList[1].ConfigId);
			this.TopPanel.RefreshSelectTipsText("RoguelikeView_4_Text", false, new object[]
			{
				new TableTextArgNew((rogueCharacterConfig != null) ? rogueCharacterConfig.GetValueOrDefault().RoleName : null, Array.Empty<object>()),
				new TableTextArgNew((rogueCharacterConfig2 != null) ? rogueCharacterConfig2.GetValueOrDefault().RoleName : null, Array.Empty<object>())
			});
		}

		// Token: 0x06035C86 RID: 220294 RVA: 0x00D86F21 File Offset: 0x00D85121
		protected void RefreshElementPanel()
		{
			this.ElementPanel.Refresh(null);
		}

		// Token: 0x06035C87 RID: 220295 RVA: 0x00D86F30 File Offset: 0x00D85130
		protected void RefreshPhantomSelectItemList()
		{
			List<RogueGainEntry> rogueGainEntryList = this.GetRogueGainEntryList();
			this.RoleSelectItemLayout.RefreshByData(rogueGainEntryList, null, false);
		}

		// Token: 0x06035C88 RID: 220296 RVA: 0x00D86F52 File Offset: 0x00D85152
		protected void RefreshBtnText()
		{
			this.ButtonItem.SetShowText("RoguelikeView_14_Text");
		}

		// Token: 0x06035C89 RID: 220297 RVA: 0x00D86F64 File Offset: 0x00D85164
		private List<RogueGainEntry> GetRogueGainEntryList()
		{
			List<RogueGainEntry> list = new List<RogueGainEntry>();
			RogueGainEntry roleEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.RoleEntry;
			if (roleEntry != null)
			{
				list.Add(roleEntry);
			}
			if (this.RoguelikeChooseData.RogueGainEntryList.Count > 0)
			{
				list.Add(this.RoguelikeChooseData.RogueGainEntryList[0]);
			}
			return list;
		}

		// Token: 0x06035C8A RID: 220298 RVA: 0x00D86FBC File Offset: 0x00D851BC
		private void RefreshOldNewText()
		{
			base.GetText(4).ShowTextNew("RoguelikeView_23_Text");
			base.GetText(5).ShowTextNew("RoguelikeView_24_Text");
		}

		// Token: 0x0401EDB2 RID: 126386
		[Nullable(2)]
		protected RoguelikeChooseData RoguelikeChooseData;

		// Token: 0x0401EDB3 RID: 126387
		[Nullable(2)]
		protected TopPanel TopPanel;

		// Token: 0x0401EDB4 RID: 126388
		[Nullable(2)]
		protected ElementPanel ElementPanel;

		// Token: 0x0401EDB5 RID: 126389
		[Nullable(2)]
		protected ButtonItem ButtonItem;

		// Token: 0x0401EDB6 RID: 126390
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RoleSelectItem, RogueGainEntry> RoleSelectItemLayout;

		// Token: 0x0401EDB7 RID: 126391
		protected readonly Func<RoleSelectItem> CreateRoleSelectItem = () => new RoleSelectItem();

		// Token: 0x0200B194 RID: 45460
		[NullableContext(0)]
		private static class ERoleReplaceViewCom
		{
			// Token: 0x04037124 RID: 225572
			public const int TopPanelItem = 0;

			// Token: 0x04037125 RID: 225573
			public const int ItemListLayout = 1;

			// Token: 0x04037126 RID: 225574
			public const int ConfirmBtn = 2;

			// Token: 0x04037127 RID: 225575
			public const int ElementPanelItem = 3;

			// Token: 0x04037128 RID: 225576
			public const int OldText = 4;

			// Token: 0x04037129 RID: 225577
			public const int NewText = 5;
		}
	}
}
