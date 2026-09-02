using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006728 RID: 26408
	internal class IllustratedUnLockItem : UiPanelBase
	{
		// Token: 0x06041E06 RID: 269830 RVA: 0x010E6AF8 File Offset: 0x010E4CF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickShareBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickBuffBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickBuffTipsCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E07 RID: 269831 RVA: 0x010E6D9C File Offset: 0x010E4F9C
		protected override void OnStart()
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(15);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06041E08 RID: 269832 RVA: 0x010E6DF8 File Offset: 0x010E4FF8
		public void RefreshItem(int moonId)
		{
			PhaseOfMoon? phaseOfMoonById = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(moonId);
			if (phaseOfMoonById == null)
			{
				return;
			}
			PhaseOfMoon value = phaseOfMoonById.Value;
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			MoonPhaseSelect moonPhaseSelect = (data != null) ? data.GetMoonPhaseSelect(moonId) : null;
			if (moonPhaseSelect == null)
			{
				return;
			}
			base.SetTextureByPath(value.Texture, base.GetTexture(0), null, null);
			base.SetTextureByPath(value.BuffTexture, base.GetTexture(9), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.MoonName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), value.MoonDes, Array.Empty<object>());
			MoonLabel? moonLabelById = ConfigBase<MoonSignInConfig>.Instance.GetMoonLabelById(moonPhaseSelect.Label1);
			MoonLabel? moonLabelById2 = ConfigBase<MoonSignInConfig>.Instance.GetMoonLabelById(moonPhaseSelect.Label2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), ((moonLabelById != null) ? moonLabelById.GetValueOrDefault().MoonLabelName : null) ?? string.Empty, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), ((moonLabelById2 != null) ? moonLabelById2.GetValueOrDefault().MoonLabelName : null) ?? string.Empty, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), ((moonLabelById != null) ? moonLabelById.GetValueOrDefault().MoonText1 : null) ?? string.Empty, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), ((moonLabelById2 != null) ? moonLabelById2.GetValueOrDefault().MoonText2 : null) ?? string.Empty, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), value.BuffDes, Array.Empty<object>());
		}

		// Token: 0x06041E09 RID: 269833 RVA: 0x010E7003 File Offset: 0x010E5203
		private void OnClickShareBtn()
		{
			this.OpenShareView();
		}

		// Token: 0x06041E0A RID: 269834 RVA: 0x010E700C File Offset: 0x010E520C
		private void OpenShareView()
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			Action<bool> setNextAndBackBtnUiActive = this.SetNextAndBackBtnUiActive;
			if (setNextAndBackBtnUiActive != null)
			{
				setNextAndBackBtnUiActive(false);
			}
			UiAsyncTask task = new UiAsyncTask("OpenShareView", delegate()
			{
				IllustratedUnLockItem.<<OpenShareView>b__6_0>d <<OpenShareView>b__6_0>d;
				<<OpenShareView>b__6_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OpenShareView>b__6_0>d.<>4__this = this;
				<<OpenShareView>b__6_0>d.<>1__state = -1;
				<<OpenShareView>b__6_0>d.<>t__builder.Start<IllustratedUnLockItem.<<OpenShareView>b__6_0>d>(ref <<OpenShareView>b__6_0>d);
				return <<OpenShareView>b__6_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task).Forget();
		}

		// Token: 0x06041E0B RID: 269835 RVA: 0x010E706C File Offset: 0x010E526C
		private UniTask OpenShareViewAsync()
		{
			IllustratedUnLockItem.<OpenShareViewAsync>d__7 <OpenShareViewAsync>d__;
			<OpenShareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenShareViewAsync>d__.<>4__this = this;
			<OpenShareViewAsync>d__.<>1__state = -1;
			<OpenShareViewAsync>d__.<>t__builder.Start<IllustratedUnLockItem.<OpenShareViewAsync>d__7>(ref <OpenShareViewAsync>d__);
			return <OpenShareViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041E0C RID: 269836 RVA: 0x010E70B0 File Offset: 0x010E52B0
		private UniTask WaitFrame()
		{
			IllustratedUnLockItem.<WaitFrame>d__8 <WaitFrame>d__;
			<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFrame>d__.<>1__state = -1;
			<WaitFrame>d__.<>t__builder.Start<IllustratedUnLockItem.<WaitFrame>d__8>(ref <WaitFrame>d__);
			return <WaitFrame>d__.<>t__builder.Task;
		}

		// Token: 0x06041E0D RID: 269837 RVA: 0x010E70EC File Offset: 0x010E52EC
		private void OnClickBuffBtn()
		{
			base.GetItem(13).SetUIActive(true);
			UUIButtonComponent button = base.GetButton(15);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06041E0E RID: 269838 RVA: 0x010E7128 File Offset: 0x010E5328
		private void OnClickBuffTipsCloseBtn()
		{
			base.GetItem(13).SetUIActive(false);
			UUIButtonComponent button = base.GetButton(15);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06041E0F RID: 269839 RVA: 0x010E7164 File Offset: 0x010E5364
		public void RefreshShareBtn()
		{
			bool uiactive = ControllerBase<ChannelController>.Instance.CouldShare();
			base.GetButton(2).RootUIComp.Get().SetUIActive(uiactive);
		}

		// Token: 0x04024C20 RID: 150560
		[Nullable(2)]
		public Action<bool> SetNextAndBackBtnUiActive;

		// Token: 0x0200C759 RID: 51033
		private class EIllustratedUnLockItemDefine
		{
			// Token: 0x0403D5E1 RID: 251361
			public const int MoonTexture = 0;

			// Token: 0x0403D5E2 RID: 251362
			public const int MoonNameText = 1;

			// Token: 0x0403D5E3 RID: 251363
			public const int ShareBtn = 2;

			// Token: 0x0403D5E4 RID: 251364
			public const int StaticTitleText = 3;

			// Token: 0x0403D5E5 RID: 251365
			public const int MoonLabel1NameText = 4;

			// Token: 0x0403D5E6 RID: 251366
			public const int MoonLabel1DesText = 5;

			// Token: 0x0403D5E7 RID: 251367
			public const int MoonLabel2NameText = 6;

			// Token: 0x0403D5E8 RID: 251368
			public const int MoonLabel2DesText = 7;

			// Token: 0x0403D5E9 RID: 251369
			public const int MoonBuffNameText = 8;

			// Token: 0x0403D5EA RID: 251370
			public const int MoonBuffTexture = 9;

			// Token: 0x0403D5EB RID: 251371
			public const int MoonBuffUpItem = 10;

			// Token: 0x0403D5EC RID: 251372
			public const int MoonDesText = 11;

			// Token: 0x0403D5ED RID: 251373
			public const int BuffBtn = 12;

			// Token: 0x0403D5EE RID: 251374
			public const int BuffTipsItem = 13;

			// Token: 0x0403D5EF RID: 251375
			public const int BuffTipsText = 14;

			// Token: 0x0403D5F0 RID: 251376
			public const int BuffTipsCloseBtn = 15;
		}
	}
}
