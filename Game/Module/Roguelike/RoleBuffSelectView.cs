using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B5 RID: 20917
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleBuffSelectView : RogueSelectBaseView
	{
		// Token: 0x06035C67 RID: 220263 RVA: 0x00D8652E File Offset: 0x00D8472E
		[NullableContext(1)]
		public RoleBuffSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035C68 RID: 220264 RVA: 0x00D86538 File Offset: 0x00D84738
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C69 RID: 220265 RVA: 0x00D86628 File Offset: 0x00D84828
		private void ConfirmBtn(int _)
		{
			if (this.RoguelikeChooseData.RogueGainEntryList.Count <= 0)
			{
				RoguelikeChooseDataResultRequest roguelikeChooseDataResultRequest = new RoguelikeChooseDataResultRequest();
				RoguelikeChooseDataResultRequest roguelikeChooseDataResultRequest2 = roguelikeChooseDataResultRequest;
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				roguelikeChooseDataResultRequest2.BindId = ((roguelikeChooseData != null) ? roguelikeChooseData.Index : 0);
				roguelikeChooseDataResultRequest.Layer = ModelBase<RoguelikeModel>.Instance.CurRoomCount;
				Singleton<Net>.Instance.Call<RoguelikeChooseDataResultResponse>(ERequestMessageId.RoguelikeChooseDataResultRequest, roguelikeChooseDataResultRequest, delegate(RoguelikeChooseDataResultResponse _, Net.CallbackStatus _)
				{
					Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool _)
					{
						RoguelikeChooseData roguelikeChooseData2 = this.RoguelikeChooseData;
						if (roguelikeChooseData2 == null)
						{
							return;
						}
						Action callBack = roguelikeChooseData2.CallBack;
						if (callBack == null)
						{
							return;
						}
						callBack();
					});
				}, 0);
				return;
			}
			RoleBuffSelectItem roleBuffSelectItem = this.GetRoleBuffSelectItem();
			if (roleBuffSelectItem == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.ZJC, "当前没有选中的角色Buff", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = roleBuffSelectItem.RogueGainEntry;
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Role);
		}

		// Token: 0x06035C6A RID: 220266 RVA: 0x00D866D8 File Offset: 0x00D848D8
		private void OnToggleStateChange(int index, bool state)
		{
			this.RoleBuffSelectLayout.DeselectCurrentGridProxy();
			if (state)
			{
				this.RoleBuffSelectLayout.SelectGridProxy(index, false);
			}
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035C6B RID: 220267 RVA: 0x00D866FC File Offset: 0x00D848FC
		protected void RefreshBtnEnableClick()
		{
			List<RogueGainEntry> rogueGainEntryList = this.RoguelikeChooseData.RogueGainEntryList;
			if (rogueGainEntryList != null && rogueGainEntryList.Count <= 0)
			{
				this.ButtonItem.SetEnableClick(true);
				return;
			}
			RoleBuffSelectItem roleBuffSelectItem = this.GetRoleBuffSelectItem();
			this.ButtonItem.SetEnableClick(roleBuffSelectItem != null);
		}

		// Token: 0x06035C6C RID: 220268 RVA: 0x00D8674C File Offset: 0x00D8494C
		protected RoleBuffSelectItem GetRoleBuffSelectItem()
		{
			foreach (RoleBuffSelectItem roleBuffSelectItem in this.RoleBuffSelectLayout.GetLayoutItemList())
			{
				if (roleBuffSelectItem.IsSelect())
				{
					return roleBuffSelectItem;
				}
			}
			return null;
		}

		// Token: 0x06035C6D RID: 220269 RVA: 0x00D867AC File Offset: 0x00D849AC
		protected override UniTask OnBeforeStartAsync()
		{
			RoleBuffSelectView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleBuffSelectView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C6E RID: 220270 RVA: 0x00D867F0 File Offset: 0x00D849F0
		protected override void OnStart()
		{
			ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry = null;
			this.RoguelikeChooseData = (RoguelikeChooseData)this.OpenParam;
			this.TopPanel.CloseCallback = new Action(base.CloseMySelf);
			this.ButtonItem = new ButtonItem(base.GetButton(4).GetRootComponent());
			this.ButtonItem.SetFunction(new Action<int>(this.ConfirmBtn));
			this.RoleBuffSelectLayout = new GenericLayout<RoleBuffSelectItem, RogueGainEntry>(base.GetVerticalLayout(2), new Func<RoleBuffSelectItem>(this.CreateRoleBuffItem), null, false, true);
			this.RefreshPanel();
		}

		// Token: 0x06035C6F RID: 220271 RVA: 0x00D86885 File Offset: 0x00D84A85
		[NullableContext(1)]
		private RoleBuffSelectItem CreateRoleBuffItem()
		{
			RoleBuffSelectItem roleBuffSelectItem = new RoleBuffSelectItem();
			roleBuffSelectItem.SetToggleStateChangeCallback(new Action<int, bool>(this.OnToggleStateChange));
			roleBuffSelectItem.OnClickBtnDetailCallback = new Action<int>(this.OnClickBtnDetail);
			return roleBuffSelectItem;
		}

		// Token: 0x06035C70 RID: 220272 RVA: 0x00D868B0 File Offset: 0x00D84AB0
		protected override void OnBeforeDestroy()
		{
			this.TopPanel.Destroy(null);
		}

		// Token: 0x06035C71 RID: 220273 RVA: 0x00D868C0 File Offset: 0x00D84AC0
		protected override void OnDescModelChange()
		{
			foreach (RoleBuffSelectItem roleBuffSelectItem in this.RoleBuffSelectLayout.GetLayoutItemList())
			{
				roleBuffSelectItem.RefreshPanel();
			}
		}

		// Token: 0x06035C72 RID: 220274 RVA: 0x00D86918 File Offset: 0x00D84B18
		private void RefreshPanel()
		{
			this.RefreshTopPanel();
			this.RefreshRoleBuffList();
			this.RefreshBtnText();
			this.RefreshBtnEnableClick();
		}

		// Token: 0x06035C73 RID: 220275 RVA: 0x00D86932 File Offset: 0x00D84B32
		private void RefreshTopPanel()
		{
			this.TopPanel.RefreshTitle("RoguelikeView_7_Text");
			this.TopPanel.RefreshSelectTipsText("RoguelikeView_8_Text", true, Array.Empty<object>());
		}

		// Token: 0x06035C74 RID: 220276 RVA: 0x00D8695A File Offset: 0x00D84B5A
		private void RefreshRoleBuffList()
		{
			this.RoleBuffSelectLayout.RefreshByData(this.RoguelikeChooseData.RogueGainEntryList ?? new List<RogueGainEntry>(), null, false);
		}

		// Token: 0x06035C75 RID: 220277 RVA: 0x00D8697D File Offset: 0x00D84B7D
		protected void RefreshBtnText()
		{
			this.ButtonItem.SetShowText("RoguelikeView_15_Text");
		}

		// Token: 0x06035C76 RID: 220278 RVA: 0x00D86990 File Offset: 0x00D84B90
		[NullableContext(1)]
		protected override void RoguelikeChooseDataResult(RogueGainEntry newRogueGainEntry, RogueGainEntry oldRogueGainEntry, bool isSuccess, int bindId, RoguelikeChooseDataResultResponse response)
		{
			if (isSuccess)
			{
				RoguelikeChooseData roguelikeChooseData = this.RoguelikeChooseData;
				int? num = (roguelikeChooseData != null) ? new int?(roguelikeChooseData.Index) : null;
				if (bindId == num.GetValueOrDefault() & num != null)
				{
					RoleBuffSelectItem roleBuffSelectItem = this.GetRoleBuffSelectItem();
					RogueSelectResult rogueSelectResult = new RogueSelectResult(newRogueGainEntry, oldRogueGainEntry, (roleBuffSelectItem != null) ? roleBuffSelectItem.RogueGainEntry : null, false);
					rogueSelectResult.CallBack = this.RoguelikeChooseData.CallBack;
					Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.RogueRoleSelectResultView, rogueSelectResult, null, true);
					return;
				}
			}
		}

		// Token: 0x06035C77 RID: 220279 RVA: 0x00D86A20 File Offset: 0x00D84C20
		private void OnClickBtnDetail(int index)
		{
			List<RogueGainEntry> rogueGainEntryList = this.RoguelikeChooseData.RogueGainEntryList;
			List<int> list = new List<int>();
			foreach (RogueGainEntry rogueGainEntry in rogueGainEntryList)
			{
				list.Add(rogueGainEntry.ConfigId);
			}
			RoguelikeRoleAffixDetailViewParam param = new RoguelikeRoleAffixDetailViewParam
			{
				Index = index,
				AffixIds = list
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeRoleAffixDetailView, param, null);
		}

		// Token: 0x0401EDAE RID: 126382
		private RoguelikeChooseData RoguelikeChooseData;

		// Token: 0x0401EDAF RID: 126383
		private TopPanel TopPanel;

		// Token: 0x0401EDB0 RID: 126384
		protected ButtonItem ButtonItem;

		// Token: 0x0401EDB1 RID: 126385
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RoleBuffSelectItem, RogueGainEntry> RoleBuffSelectLayout;

		// Token: 0x0200B192 RID: 45458
		[NullableContext(0)]
		public static class ERoleBuffSelectViewCom
		{
			// Token: 0x0403711A RID: 225562
			public const int TopPanelItem = 0;

			// Token: 0x0403711B RID: 225563
			public const int RoleTexture = 1;

			// Token: 0x0403711C RID: 225564
			public const int RoleBuffListLayout = 2;

			// Token: 0x0403711D RID: 225565
			public const int RoleBuffItem = 3;

			// Token: 0x0403711E RID: 225566
			public const int ConfirmBtn = 4;

			// Token: 0x0403711F RID: 225567
			public const int RoleShadowTexture = 5;
		}
	}
}
