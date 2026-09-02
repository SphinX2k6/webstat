using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B9 RID: 20921
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSelectResultView : RogueSelectResultBaseView
	{
		// Token: 0x06035C9F RID: 220319 RVA: 0x00D876E4 File Offset: 0x00D858E4
		public RoleSelectResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035CA0 RID: 220320 RVA: 0x00D87714 File Offset: 0x00D85914
		protected override UniTask OnCreateAsync()
		{
			RoleSelectResultView.<OnCreateAsync>d__4 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<RoleSelectResultView.<OnCreateAsync>d__4>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035CA1 RID: 220321 RVA: 0x00D87758 File Offset: 0x00D85958
		protected override void OnStart()
		{
			base.OnStart();
			this.UiPoolActorPrivate.UiItem.SetUIParent(base.GetHorizontalLayout(3).GetRootComponent(), false);
			this.RogueSelectResult = (this.OpenParam as RogueSelectResult);
			this.RoleSelectItemLayout = new GenericLayout<RoleSelectItem, RogueGainEntry>(base.GetHorizontalLayout(3), this.CreateRoleSelectItem, null, false, true);
		}

		// Token: 0x06035CA2 RID: 220322 RVA: 0x00D877B4 File Offset: 0x00D859B4
		protected override void OnBeforeDestroy()
		{
			if (this.UiPoolActorPrivate != null)
			{
				Singleton<UiActorPool>.Instance.RecycleAsync(this.UiPoolActorPrivate, "UiItem_RoleSelectItem_Prefab");
			}
		}

		// Token: 0x06035CA3 RID: 220323 RVA: 0x00D877D3 File Offset: 0x00D859D3
		protected override void OnCloseBtnClick()
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
		}

		// Token: 0x06035CA4 RID: 220324 RVA: 0x00D877E7 File Offset: 0x00D859E7
		protected override void OnDescModelChange()
		{
			this.Refresh();
		}

		// Token: 0x06035CA5 RID: 220325 RVA: 0x00D877EF File Offset: 0x00D859EF
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06035CA6 RID: 220326 RVA: 0x00D877F7 File Offset: 0x00D859F7
		protected override void Refresh()
		{
			this.RefreshPhantomSelectItemList();
			this.RefreshTitleText();
		}

		// Token: 0x06035CA7 RID: 220327 RVA: 0x00D87808 File Offset: 0x00D85A08
		private void RefreshPhantomSelectItemList()
		{
			this.RoleSelectItemLayout.RefreshByDataAsync(new <>z__ReadOnlySingleElementList<RogueGainEntry>(this.RogueSelectResult.NewRogueGainEntry), false, null).ContinueWith(new Action(this.RefreshNewRoleBuff));
		}

		// Token: 0x06035CA8 RID: 220328 RVA: 0x00D8784C File Offset: 0x00D85A4C
		private void RefreshNewRoleBuff()
		{
			RogueGainEntry newRogueGainEntry = this.RogueSelectResult.NewRogueGainEntry;
			RogueGainEntry oldRogueGainEntry = this.RogueSelectResult.OldRogueGainEntry;
			HashSet<long> hashSet = new HashSet<long>();
			if (newRogueGainEntry != null)
			{
				foreach (AffixEntry affixEntry in newRogueGainEntry.AffixEntryList)
				{
					bool flag = false;
					if (((oldRogueGainEntry != null) ? oldRogueGainEntry.AffixEntryList : null) != null)
					{
						foreach (AffixEntry affixEntry2 in oldRogueGainEntry.AffixEntryList)
						{
							int? id = affixEntry2.Id;
							int value = affixEntry.Id.Value;
							if (id.GetValueOrDefault() == value & id != null)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag && !hashSet.Contains((long)affixEntry.Id.Value))
					{
						hashSet.Add((long)affixEntry.Id.Value);
					}
				}
			}
			if (hashSet.Count <= 0)
			{
				return;
			}
			RoleSelectItem layoutItemByIndex = this.RoleSelectItemLayout.GetLayoutItemByIndex(0);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.SetSecondColorForAttrItem(hashSet);
		}

		// Token: 0x06035CA9 RID: 220329 RVA: 0x00D87990 File Offset: 0x00D85B90
		protected void RefreshTitleText()
		{
			base.GetText(4).ShowTextNew("RoguelikeView_18_Text");
		}

		// Token: 0x0401EDBE RID: 126398
		[Nullable(2)]
		private RogueSelectResult RogueSelectResult;

		// Token: 0x0401EDBF RID: 126399
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoleSelectItem, RogueGainEntry> RoleSelectItemLayout;

		// Token: 0x0401EDC0 RID: 126400
		[Nullable(2)]
		protected UiPoolActor UiPoolActorPrivate;

		// Token: 0x0401EDC1 RID: 126401
		private readonly Func<RoleSelectItem> CreateRoleSelectItem = () => new RoleSelectItem();
	}
}
