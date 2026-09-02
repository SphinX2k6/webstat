using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065AC RID: 26028
	public class PinballWeaponTipsTopView : UiPanelBase
	{
		// Token: 0x06041076 RID: 266358 RVA: 0x010AF640 File Offset: 0x010AD840
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickLockToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041077 RID: 266359 RVA: 0x010AF749 File Offset: 0x010AD949
		[NullableContext(1)]
		public void Refresh(PinballWeaponData data)
		{
			this.Data = data;
			this.RefreshUi();
		}

		// Token: 0x06041078 RID: 266360 RVA: 0x010AF758 File Offset: 0x010AD958
		public void SetLockToggleShowState(bool bShow)
		{
			this.LockToggleShowState = bShow;
		}

		// Token: 0x06041079 RID: 266361 RVA: 0x010AF764 File Offset: 0x010AD964
		private void RefreshUi()
		{
			if (this.Data == null)
			{
				return;
			}
			this.RefreshLockToggleShowState();
			PinballWeaponQuality? pinballWeaponQuality;
			base.TrySetTextureByPath((ConfigBase<PinballConfig>.Instance.GetPinballWeaponQualityConfigById(this.Data.Quality) != null) ? pinballWeaponQuality.GetValueOrDefault().TexQuality : null, base.GetTexture(0), null, null);
			base.TrySetTextureByPath(this.Data.Icon, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), this.Data.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), ConfigBase<PinballConfig>.Instance.GetPinballWeaponTypeName(this.Data.Type), Array.Empty<object>());
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(this.Data.GetIsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0604107A RID: 266362 RVA: 0x010AF85C File Offset: 0x010ADA5C
		public void RefreshLockToggleShowState()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(this.LockToggleShowState);
		}

		// Token: 0x0604107B RID: 266363 RVA: 0x010AF890 File Offset: 0x010ADA90
		private void OnClickLockToggle(EToggleState state)
		{
			if (this.Data == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PinballBattle, ELogAuthor.CB, "锁定武器失败，武器数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			PinballController pinballController = ActivityManager.GetActivityController(ActivityType.PinballActivity) as PinballController;
			bool bLock = state == EToggleState.ETT_UnChecked;
			pinballController.RequestWeaponLock(this.Data.IncId, bLock);
		}

		// Token: 0x04024749 RID: 149321
		[Nullable(1)]
		private PinballWeaponData Data;

		// Token: 0x0402474A RID: 149322
		private bool LockToggleShowState = true;

		// Token: 0x0200C5A4 RID: 50596
		private enum EComponent
		{
			// Token: 0x0403CD47 RID: 249159
			TexQuality,
			// Token: 0x0403CD48 RID: 249160
			TexWeaponIcon,
			// Token: 0x0403CD49 RID: 249161
			TextName,
			// Token: 0x0403CD4A RID: 249162
			TextType,
			// Token: 0x0403CD4B RID: 249163
			LockToggle
		}
	}
}
