using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A2 RID: 24738
	[NullableContext(1)]
	[Nullable(0)]
	public class SilentAreaInfoItem : UiPanelBase
	{
		// Token: 0x0603E745 RID: 255813 RVA: 0x00FF6418 File Offset: 0x00FF4618
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E746 RID: 255814 RVA: 0x00FF64A4 File Offset: 0x00FF46A4
		public void Initialize(AActor actor, ILevelPlayInformation config)
		{
			base.CreateByActorAsync(actor, null, false).ContinueWith(delegate()
			{
				this.UpdateItem(config);
			}).Forget();
		}

		// Token: 0x0603E747 RID: 255815 RVA: 0x00FF64E4 File Offset: 0x00FF46E4
		public void SetCurrentShowType(EInformationViewType type)
		{
			this.CurrentShowType = type;
		}

		// Token: 0x0603E748 RID: 255816 RVA: 0x00FF64F0 File Offset: 0x00FF46F0
		protected override UniTask OnBeforeStartAsync()
		{
			SilentAreaInfoItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SilentAreaInfoItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E749 RID: 255817 RVA: 0x00FF6533 File Offset: 0x00FF4733
		public void UpdateItem(ILevelPlayInformation config)
		{
			this.UpdateTitleText(config.TidMainTitle);
			this.UpdateSubItems(config.SubTitles);
		}

		// Token: 0x0603E74A RID: 255818 RVA: 0x00FF6550 File Offset: 0x00FF4750
		private void UpdateTitleText(string title)
		{
			UUIText text = base.GetText(0);
			string newText;
			if (this.CurrentShowType == EInformationViewType.LevelPlay)
			{
				newText = Singleton<PublicUtil>.Instance.GetConfigTextByKey(title);
			}
			else
			{
				newText = ConfigMultiTextLang.GetLocalTextNew(title, null);
			}
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0603E74B RID: 255819 RVA: 0x00FF6590 File Offset: 0x00FF4790
		private void UpdateSubItems(List<IInformationSubTitle> subConfigs)
		{
			for (int i = 0; i < subConfigs.Count; i++)
			{
				IInformationSubTitle config = subConfigs[i];
				if (i < this.SubItems.Count)
				{
					SilentAreaInfoSubItem silentAreaInfoSubItem = this.SubItems[i];
					silentAreaInfoSubItem.SetCurrentShowType(this.CurrentShowType);
					silentAreaInfoSubItem.UpdateItem(config);
				}
				else
				{
					UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(1), base.GetItem(2));
					SilentAreaInfoSubItem silentAreaInfoSubItem = new SilentAreaInfoSubItem();
					silentAreaInfoSubItem.SetCurrentShowType(this.CurrentShowType);
					silentAreaInfoSubItem.Initialize(uuiitem.GetOwner(), config);
					this.SubItems.Add(silentAreaInfoSubItem);
				}
			}
			for (int j = 0; j < this.SubItems.Count; j++)
			{
				this.SubItems[j].SetActive(j < subConfigs.Count);
			}
		}

		// Token: 0x04023031 RID: 143409
		private EInformationViewType CurrentShowType;

		// Token: 0x04023032 RID: 143410
		private readonly List<SilentAreaInfoSubItem> SubItems = new List<SilentAreaInfoSubItem>();

		// Token: 0x0200C1B0 RID: 49584
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403BA32 RID: 244274
			ParentTitleText,
			// Token: 0x0403BA33 RID: 244275
			SubItem,
			// Token: 0x0403BA34 RID: 244276
			SubItemRoot
		}
	}
}
