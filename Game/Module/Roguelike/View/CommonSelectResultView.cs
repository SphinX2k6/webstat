using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike.View
{
	// Token: 0x020051C1 RID: 20929
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonSelectResultView : RogueSelectResultBaseView
	{
		// Token: 0x06035CF1 RID: 220401 RVA: 0x00D89645 File Offset: 0x00D87845
		[NullableContext(1)]
		public CommonSelectResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035CF2 RID: 220402 RVA: 0x00D89650 File Offset: 0x00D87850
		protected override void OnCloseBtnClick()
		{
			if (!this.CommonSelectItem.GetRootItem().IsUIActiveInHierarchy())
			{
				base.CloseMe(delegate(bool _)
				{
					RogueSelectResult rogueSelectResult = this.RogueSelectResult;
					if (rogueSelectResult == null)
					{
						return;
					}
					Action callBack = rogueSelectResult.CallBack;
					if (callBack == null)
					{
						return;
					}
					callBack();
				});
				return;
			}
			this.CommonSelectItem.GetRootItem().SetUIActive(false);
			this.ExtraCommonSelectItem.GetRootItem().SetUIActive(false);
			if (this.RogueSelectResult.GetNewUnlockAffixEntry().Count <= 0)
			{
				base.CloseMe(delegate(bool _)
				{
					RogueSelectResult rogueSelectResult = this.RogueSelectResult;
					if (rogueSelectResult == null)
					{
						return;
					}
					Action callBack = rogueSelectResult.CallBack;
					if (callBack == null)
					{
						return;
					}
					callBack();
				});
				return;
			}
			this.PhantomSelectItem.GetRootItem().SetUIActive(true);
			base.GetText(4).ShowTextNew("RoguelikeView_21_Text");
			this.InitPhantomSelectItem();
		}

		// Token: 0x06035CF3 RID: 220403 RVA: 0x00D896F4 File Offset: 0x00D878F4
		protected override UniTask OnBeforeStartAsync()
		{
			CommonSelectResultView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonSelectResultView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035CF4 RID: 220404 RVA: 0x00D89738 File Offset: 0x00D87938
		private void InitCommonSelectItem()
		{
			if (this.RogueSelectResult.SelectRogueGainEntry != null)
			{
				this.CommonSelectItem.Update(this.RogueSelectResult.SelectRogueGainEntry);
				this.CommonSelectItem.SetToggleUnDetermined();
			}
			if (this.RogueSelectResult.ExtraRogueGainEntry != null)
			{
				this.ExtraCommonSelectItem.Update(this.RogueSelectResult.ExtraRogueGainEntry);
				this.ExtraCommonSelectItem.SetToggleUnDetermined();
			}
		}

		// Token: 0x06035CF5 RID: 220405 RVA: 0x00D897A4 File Offset: 0x00D879A4
		private void InitPhantomSelectItem()
		{
			PhantomSelectItemContextData data = new PhantomSelectItemContextData
			{
				RogueGainEntry = this.RogueSelectResult.NewRogueGainEntry,
				RoguelikeInfo = ModelBase<RoguelikeModel>.Instance.RogueInfo
			};
			this.PhantomSelectItem.Update(data);
			this.PhantomSelectItem.SetToggleUnDetermined();
		}

		// Token: 0x06035CF6 RID: 220406 RVA: 0x00D897F0 File Offset: 0x00D879F0
		protected override void OnBeforeDestroy()
		{
			CommonSelectItem commonSelectItem = this.CommonSelectItem;
			if (commonSelectItem != null)
			{
				commonSelectItem.Destroy(null);
			}
			if (this.CommonItemActor != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.CommonItemActor, "UiItem_CommonSelectItem_Prefab");
			}
			CommonSelectItem extraCommonSelectItem = this.ExtraCommonSelectItem;
			if (extraCommonSelectItem != null)
			{
				extraCommonSelectItem.Destroy(null);
			}
			if (this.ExtraCommonItemActor != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.ExtraCommonItemActor, "UiItem_CommonSelectItem_Prefab");
			}
			PhantomSelectItem phantomSelectItem = this.PhantomSelectItem;
			if (phantomSelectItem != null)
			{
				phantomSelectItem.Destroy(null);
			}
			if (this.PhantomItemActor != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.PhantomItemActor, "UiItem_PhantomSelectItem_Prefab");
			}
		}

		// Token: 0x06035CF7 RID: 220407 RVA: 0x00D8988A File Offset: 0x00D87A8A
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035CF8 RID: 220408 RVA: 0x00D89892 File Offset: 0x00D87A92
		protected override void Refresh()
		{
			this.CommonSelectItem.RefreshPanel();
			this.ExtraCommonSelectItem.RefreshPanel();
			this.PhantomSelectItem.RefreshPanel();
			this.RefreshTitleText();
		}

		// Token: 0x06035CF9 RID: 220409 RVA: 0x00D898BC File Offset: 0x00D87ABC
		protected void RefreshTitleText()
		{
			string key = null;
			if (this.RogueSelectResult.IsShowCommon)
			{
				key = "RoguelikeView_20_Text";
			}
			else if (this.RogueSelectResult.GetNewUnlockAffixEntry().Count > 0)
			{
				key = "RoguelikeView_21_Text";
			}
			base.GetText(4).ShowTextNew(key);
		}

		// Token: 0x06035CFA RID: 220410 RVA: 0x00D89908 File Offset: 0x00D87B08
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length != 1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "聚焦引导extraParam项配置有误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (configParams[0] == "Sub")
			{
				PhantomSelectItem phantomSelectItem = this.PhantomSelectItem;
				UUIItem uuiitem = (phantomSelectItem != null) ? phantomSelectItem.GetSubItem() : null;
				if (uuiitem != null)
				{
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
			}
			return null;
		}

		// Token: 0x0401EDD6 RID: 126422
		private RogueSelectResult RogueSelectResult;

		// Token: 0x0401EDD7 RID: 126423
		private readonly UiPoolActor CommonItemActor;

		// Token: 0x0401EDD8 RID: 126424
		private CommonSelectItem CommonSelectItem;

		// Token: 0x0401EDD9 RID: 126425
		private readonly UiPoolActor ExtraCommonItemActor;

		// Token: 0x0401EDDA RID: 126426
		private CommonSelectItem ExtraCommonSelectItem;

		// Token: 0x0401EDDB RID: 126427
		private readonly UiPoolActor PhantomItemActor;

		// Token: 0x0401EDDC RID: 126428
		private PhantomSelectItem PhantomSelectItem;
	}
}
