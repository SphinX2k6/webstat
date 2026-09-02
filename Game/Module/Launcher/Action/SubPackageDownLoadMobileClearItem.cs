using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui;
using CSharpScript.Launcher.Ui.HotFix;
using UnrealEngine;

namespace CSharpScript.Game.Module.Launcher.Action
{
	// Token: 0x02004A8E RID: 19086
	public class SubPackageDownLoadMobileClearItem : LaunchComponentsAction, IHotFixLayoutItem
	{
		// Token: 0x06031CC8 RID: 203976 RVA: 0x00C78C24 File Offset: 0x00C76E24
		[NullableContext(1)]
		public void SetRootActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x06031CC9 RID: 203977 RVA: 0x00C78C30 File Offset: 0x00C76E30
		protected override void OnStart()
		{
			this.TitleItem = new SubPackageDownLoadMobileClearTitleItem();
			this.TitleItem.SetRootActorLaunchComponentsAction(base.GetItem(0).GetOwner());
			this.TitleItem.OnClickHelpBtnCallBack = this.OnClickHelpBtnCallBack;
			UUILayoutBase layout = base.GetLayout(1);
			AUIBaseActor gridActor = base.GetItem(2).GetOwner() as AUIBaseActor;
			this.InfoItemLayout = new HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData>(layout, () => new SubPackageDownLoadMobileClearInfoItem
			{
				OnClickToggleCallBack = this.OnClickToggleCallBack
			}, gridActor);
		}

		// Token: 0x06031CCA RID: 203978 RVA: 0x00C78CA4 File Offset: 0x00C76EA4
		[NullableContext(1)]
		public virtual void Refresh(IHotFixLayoutData data)
		{
			ISubPackageDownLoadMobileClearData subPackageDownLoadMobileClearData = (ISubPackageDownLoadMobileClearData)data;
			SubPackageDownLoadMobileClearTitleItem titleItem = this.TitleItem;
			if (titleItem != null)
			{
				titleItem.RefreshItem(subPackageDownLoadMobileClearData.TitleId);
			}
			SubPackageDownLoadMobileClearTitleItem titleItem2 = this.TitleItem;
			if (titleItem2 != null)
			{
				titleItem2.SetActive(true);
			}
			List<SubPackageDownLoadMobileClearInfoItemData> list = new List<SubPackageDownLoadMobileClearInfoItemData>();
			if (subPackageDownLoadMobileClearData.TitleId == 3)
			{
				SubPackageDownLoadMobileClearInfoItemData item = new SubPackageDownLoadMobileClearInfoItemData
				{
					Type = ESubPackageDownLoadPackageType.OptionalPlot,
					HaveVideoCanClear = subPackageDownLoadMobileClearData.HaveVideoCanClear
				};
				list.Add(item);
			}
			else
			{
				if (subPackageDownLoadMobileClearData.TitleId == 2)
				{
					using (List<int>.Enumerator enumerator = (subPackageDownLoadMobileClearData.SceneIdList ?? new List<int>()).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							int value = enumerator.Current;
							SubPackageDownLoadMobileClearInfoItemData item2 = new SubPackageDownLoadMobileClearInfoItemData
							{
								Type = ESubPackageDownLoadPackageType.OptionalScene,
								SceneId = new int?(value)
							};
							list.Add(item2);
						}
						goto IL_12A;
					}
				}
				if (subPackageDownLoadMobileClearData.TitleId == 5)
				{
					foreach (string voiceLanguageCode in (subPackageDownLoadMobileClearData.VoiceLanguageCodeList ?? new List<string>()))
					{
						SubPackageDownLoadMobileClearInfoItemData item3 = new SubPackageDownLoadMobileClearInfoItemData
						{
							Type = ESubPackageDownLoadPackageType.Voice,
							VoiceLanguageCode = voiceLanguageCode
						};
						list.Add(item3);
					}
				}
			}
			IL_12A:
			HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> infoItemLayout = this.InfoItemLayout;
			if (infoItemLayout == null)
			{
				return;
			}
			infoItemLayout.RefreshByData(list);
		}

		// Token: 0x06031CCB RID: 203979 RVA: 0x00C78E08 File Offset: 0x00C77008
		public void UnSelectItem()
		{
			SubPackageDownLoadMobileClearTitleItem titleItem = this.TitleItem;
			if (titleItem != null)
			{
				titleItem.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> infoItemLayout = this.InfoItemLayout;
			List<SubPackageDownLoadMobileClearInfoItem> list = ((infoItemLayout != null) ? infoItemLayout.GetLayoutItemList() : null) as List<SubPackageDownLoadMobileClearInfoItem>;
			if (list != null)
			{
				foreach (SubPackageDownLoadMobileClearInfoItem subPackageDownLoadMobileClearInfoItem in list)
				{
					subPackageDownLoadMobileClearInfoItem.UnSelectItem();
				}
			}
		}

		// Token: 0x06031CCC RID: 203980 RVA: 0x00C78E80 File Offset: 0x00C77080
		public void SelectItem(int subIndex)
		{
			if (subIndex == 0)
			{
				SubPackageDownLoadMobileClearTitleItem titleItem = this.TitleItem;
				if (titleItem != null)
				{
					titleItem.SelectItem();
				}
				HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> infoItemLayout = this.InfoItemLayout;
				List<SubPackageDownLoadMobileClearInfoItem> list = ((infoItemLayout != null) ? infoItemLayout.GetLayoutItemList() : null) as List<SubPackageDownLoadMobileClearInfoItem>;
				if (list == null)
				{
					return;
				}
				using (List<SubPackageDownLoadMobileClearInfoItem>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SubPackageDownLoadMobileClearInfoItem subPackageDownLoadMobileClearInfoItem = enumerator.Current;
						subPackageDownLoadMobileClearInfoItem.UnSelectItem();
					}
					return;
				}
			}
			SubPackageDownLoadMobileClearTitleItem titleItem2 = this.TitleItem;
			if (titleItem2 != null)
			{
				titleItem2.UnSelectItem();
			}
			HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> infoItemLayout2 = this.InfoItemLayout;
			SubPackageDownLoadMobileClearInfoItem subPackageDownLoadMobileClearInfoItem2 = ((infoItemLayout2 != null) ? infoItemLayout2.GetLayoutItemByIndex(subIndex - 1) : null) as SubPackageDownLoadMobileClearInfoItem;
			if (subPackageDownLoadMobileClearInfoItem2 == null)
			{
				return;
			}
			subPackageDownLoadMobileClearInfoItem2.SelectItem();
		}

		// Token: 0x06031CCD RID: 203981 RVA: 0x00C78F30 File Offset: 0x00C77130
		public void OnClickItem(int subIndex)
		{
			if (subIndex == 0)
			{
				this.TitleItem.ClickItemOnGamePad();
				return;
			}
			HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> infoItemLayout = this.InfoItemLayout;
			SubPackageDownLoadMobileClearInfoItem subPackageDownLoadMobileClearInfoItem = ((infoItemLayout != null) ? infoItemLayout.GetLayoutItemByIndex(subIndex - 1) : null) as SubPackageDownLoadMobileClearInfoItem;
			if (subPackageDownLoadMobileClearInfoItem == null)
			{
				return;
			}
			subPackageDownLoadMobileClearInfoItem.ClickItemOnGamePad();
		}

		// Token: 0x0401D293 RID: 119443
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIItem> OnClickHelpBtnCallBack;

		// Token: 0x0401D294 RID: 119444
		[Nullable(2)]
		public Action<int?, bool, EToggleState, string> OnClickToggleCallBack;

		// Token: 0x0401D295 RID: 119445
		[Nullable(2)]
		private SubPackageDownLoadMobileClearTitleItem TitleItem;

		// Token: 0x0401D296 RID: 119446
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private HotFixLayout<SubPackageDownLoadMobileClearInfoItem, SubPackageDownLoadMobileClearInfoItemData> InfoItemLayout;

		// Token: 0x0200AAF6 RID: 43766
		private static class ESubPackageDownLoadMobileClearItem
		{
			// Token: 0x0403535F RID: 217951
			public const int TitleItem = 0;

			// Token: 0x04035360 RID: 217952
			public const int Layout = 1;

			// Token: 0x04035361 RID: 217953
			public const int InfoItem = 2;
		}
	}
}
