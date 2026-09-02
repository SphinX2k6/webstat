using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C0D RID: 19469
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrBuildInfoView : UiViewBase
	{
		// Token: 0x06032CB6 RID: 208054 RVA: 0x00CB9D24 File Offset: 0x00CB7F24
		public VillageInfrBuildInfoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032CB7 RID: 208055 RVA: 0x00CB9D50 File Offset: 0x00CB7F50
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickMaskClose)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickBack))
			};
		}

		// Token: 0x06032CB8 RID: 208056 RVA: 0x00CB9E28 File Offset: 0x00CB8028
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IVillageInfrBuildInfoParam>(EEventName.VillageInfrMainViewOnSelect, new Action<IVillageInfrBuildInfoParam>(this.OnSelect));
			Singleton<EventSystem>.Instance.Add(EEventName.CloseVillageInfrBuildInfoView, new Action(this.OnClickMaskClose));
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrMissionItemClick, new Action(this.OnClickMaskClose));
		}

		// Token: 0x06032CB9 RID: 208057 RVA: 0x00CB9E8C File Offset: 0x00CB808C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrMainViewOnSelect, new Action<IVillageInfrBuildInfoParam>(this.OnSelect));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseVillageInfrBuildInfoView, new Action(this.OnClickMaskClose));
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrMissionItemClick, new Action(this.OnClickMaskClose));
		}

		// Token: 0x06032CBA RID: 208058 RVA: 0x00CB9EF0 File Offset: 0x00CB80F0
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrBuildInfoView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrBuildInfoView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032CBB RID: 208059 RVA: 0x00CB9F34 File Offset: 0x00CB8134
		private void SetOpenParam()
		{
			IVillageInfrBuildInfoParam villageInfrBuildInfoParam = this.OpenParam as IVillageInfrBuildInfoParam;
			this.SelectType = villageInfrBuildInfoParam.SelectType;
			this.SelectId = villageInfrBuildInfoParam.SelectId;
			this.CloseCb = villageInfrBuildInfoParam.CloseCb;
		}

		// Token: 0x06032CBC RID: 208060 RVA: 0x00CB9F74 File Offset: 0x00CB8174
		private UniTask CreateCaption()
		{
			VillageInfrBuildInfoView.<CreateCaption>d__12 <CreateCaption>d__;
			<CreateCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaption>d__.<>4__this = this;
			<CreateCaption>d__.<>1__state = -1;
			<CreateCaption>d__.<>t__builder.Start<VillageInfrBuildInfoView.<CreateCaption>d__12>(ref <CreateCaption>d__);
			return <CreateCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06032CBD RID: 208061 RVA: 0x00CB9FB8 File Offset: 0x00CB81B8
		private UniTask RefreshCurrencyList()
		{
			VillageInfrBuildInfoView.<RefreshCurrencyList>d__13 <RefreshCurrencyList>d__;
			<RefreshCurrencyList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCurrencyList>d__.<>4__this = this;
			<RefreshCurrencyList>d__.<>1__state = -1;
			<RefreshCurrencyList>d__.<>t__builder.Start<VillageInfrBuildInfoView.<RefreshCurrencyList>d__13>(ref <RefreshCurrencyList>d__);
			return <RefreshCurrencyList>d__.<>t__builder.Task;
		}

		// Token: 0x06032CBE RID: 208062 RVA: 0x00CB9FFC File Offset: 0x00CB81FC
		private UniTask CreateBuildPanel()
		{
			VillageInfrBuildInfoView.<CreateBuildPanel>d__14 <CreateBuildPanel>d__;
			<CreateBuildPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuildPanel>d__.<>4__this = this;
			<CreateBuildPanel>d__.<>1__state = -1;
			<CreateBuildPanel>d__.<>t__builder.Start<VillageInfrBuildInfoView.<CreateBuildPanel>d__14>(ref <CreateBuildPanel>d__);
			return <CreateBuildPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06032CBF RID: 208063 RVA: 0x00CBA040 File Offset: 0x00CB8240
		private UniTask CreateChatItem()
		{
			VillageInfrBuildInfoView.<CreateChatItem>d__15 <CreateChatItem>d__;
			<CreateChatItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateChatItem>d__.<>4__this = this;
			<CreateChatItem>d__.<>1__state = -1;
			<CreateChatItem>d__.<>t__builder.Start<VillageInfrBuildInfoView.<CreateChatItem>d__15>(ref <CreateChatItem>d__);
			return <CreateChatItem>d__.<>t__builder.Task;
		}

		// Token: 0x06032CC0 RID: 208064 RVA: 0x00CBA084 File Offset: 0x00CB8284
		protected override void OnStart()
		{
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			this.RefreshBuildInfo();
			this.RefreshChat(false);
		}

		// Token: 0x06032CC1 RID: 208065 RVA: 0x00CBA0B8 File Offset: 0x00CB82B8
		private void RefreshBuildInfo()
		{
			VillageInfrModel modelData = ModelBase<VillageInfrModel>.Instance;
			this.BuildPanel.SetBottomBtnClickCb(delegate
			{
				Action closeCb = this.CloseCb;
				if (closeCb != null)
				{
					closeCb();
				}
				this.CloseMe(null);
				if (this.SelectType != EVillageInfrSelectType.Tree)
				{
					SkipTaskManager.RunByConfigId(ConfigCommonParamById.GetIntConfig("VillageInfrLevelAccessPath").Value, null);
					return;
				}
				InfrV2TreeBuild? infrTreeBuild = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(this.SelectId);
				if (!modelData.GetTreeIsUnlock(this.SelectId))
				{
					SkipTaskManager.RunByConfigId(infrTreeBuild.Value.LockJumpId, null);
					return;
				}
				if (!modelData.GetCanTreeLevelUp(this.SelectId) && !modelData.GetTreeIsComplete(this.SelectId))
				{
					ControllerBase<VillageInfrController>.Instance.RequestInfrV2ManualSwitchTraceTree(this.SelectId).Forget<bool>();
					SkipTaskManager.RunByConfigId(infrTreeBuild.Value.JumpId, null);
					return;
				}
				SkipTaskManager.RunByConfigId(infrTreeBuild.Value.JumpId, null);
			});
		}

		// Token: 0x06032CC2 RID: 208066 RVA: 0x00CBA0F4 File Offset: 0x00CB82F4
		private void RefreshChat(bool isStart = false)
		{
			IReadOnlyList<InfrV2PopupMsg> popupMsgAll = ConfigBase<VillageInfrConfig>.Instance.GetPopupMsgAll();
			EVillageInfrPopupMsgType popupMsgType = this.GetPopupMsgType();
			List<InfrV2PopupMsg> list = new List<InfrV2PopupMsg>();
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				using (IEnumerator<InfrV2PopupMsg> enumerator = popupMsgAll.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						InfrV2PopupMsg item = enumerator.Current;
						if (item.Type == (int)popupMsgType && item.TreeId == this.SelectId)
						{
							list.Add(item);
						}
					}
					goto IL_A8;
				}
			}
			foreach (InfrV2PopupMsg item2 in popupMsgAll)
			{
				if (item2.Type == (int)popupMsgType)
				{
					list.Add(item2);
				}
			}
			IL_A8:
			if (list.Count <= 0)
			{
				this.ChatItem.SetShow(false, true);
				return;
			}
			this.ChatItem.SetShow(true, !isStart);
			InfrV2PopupMsg infrV2PopupMsg = list[(int)Math.Floor(new Random().NextDouble() * (double)list.Count)];
			this.ChatItem.Refresh(new VillageInfrChat
			{
				HeadTexture = infrV2PopupMsg.HeadTexturePath,
				Chat = infrV2PopupMsg.Text
			});
		}

		// Token: 0x06032CC3 RID: 208067 RVA: 0x00CBA238 File Offset: 0x00CB8438
		private EVillageInfrPopupMsgType GetPopupMsgType()
		{
			VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
			if (this.SelectType == EVillageInfrSelectType.Tree)
			{
				IVillageInfrTreeData treeData = instance.GetTreeData(this.SelectId);
				if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusLock)
				{
					return EVillageInfrPopupMsgType.TreeLock;
				}
				if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusProgress)
				{
					if (instance.GetCanTreeLevelUp(this.SelectId))
					{
						return EVillageInfrPopupMsgType.TreeCanBuild;
					}
					return EVillageInfrPopupMsgType.TreeProgress;
				}
				else
				{
					if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete)
					{
						return EVillageInfrPopupMsgType.TreeComplete;
					}
					return EVillageInfrPopupMsgType.TreeLock;
				}
			}
			else
			{
				if (instance.GetVillageLevel() >= ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel())
				{
					return EVillageInfrPopupMsgType.VillageComplete;
				}
				if (instance.GetCanVillageLevelUp())
				{
					return EVillageInfrPopupMsgType.VillageCanBuild;
				}
				return EVillageInfrPopupMsgType.VillageProgress;
			}
		}

		// Token: 0x06032CC4 RID: 208068 RVA: 0x00CBA2BB File Offset: 0x00CB84BB
		private void OnClickMaskClose()
		{
			Action closeCb = this.CloseCb;
			if (closeCb != null)
			{
				closeCb();
			}
			base.CloseMe(null);
		}

		// Token: 0x06032CC5 RID: 208069 RVA: 0x00CBA2D5 File Offset: 0x00CB84D5
		private void OnClickBack()
		{
			Action closeCb = this.CloseCb;
			if (closeCb != null)
			{
				closeCb();
			}
			base.CloseMe(null);
		}

		// Token: 0x06032CC6 RID: 208070 RVA: 0x00CBA2EF File Offset: 0x00CB84EF
		public void SetCloseCallBack(Action cb)
		{
			this.CloseCb = cb;
		}

		// Token: 0x06032CC7 RID: 208071 RVA: 0x00CBA2F8 File Offset: 0x00CB84F8
		private void OnSelect(IVillageInfrBuildInfoParam param)
		{
			this.OpenParam = param;
			this.SetOpenParam();
			this.RefreshCurrencyList().Forget();
			this.RefreshBuildInfo();
			this.RefreshChat(false);
			this.BuildPanel.Refresh(param);
		}

		// Token: 0x0401D8F1 RID: 121073
		private int SelectId;

		// Token: 0x0401D8F2 RID: 121074
		private EVillageInfrSelectType SelectType;

		// Token: 0x0401D8F3 RID: 121075
		private readonly PopupCaptionItem Caption = new PopupCaptionItem(null);

		// Token: 0x0401D8F4 RID: 121076
		private readonly VillageInfrBuildPanel BuildPanel = new VillageInfrBuildPanel();

		// Token: 0x0401D8F5 RID: 121077
		private readonly ChatItem ChatItem = new ChatItem();

		// Token: 0x0401D8F6 RID: 121078
		[Nullable(2)]
		private Action CloseCb;
	}
}
