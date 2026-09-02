using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F44 RID: 28484
	[NullableContext(1)]
	[Nullable(0)]
	public class CipherView : UiTickViewBase
	{
		// Token: 0x06044F25 RID: 282405 RVA: 0x011F2275 File Offset: 0x011F0475
		public CipherView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044F26 RID: 282406 RVA: 0x011F2280 File Offset: 0x011F0480
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (this.CipherKeyIndexList == null)
			{
				this.CipherKeyIndexList = new List<int>();
			}
			this.CipherKeyIndexList.Clear();
			for (int i = 0; i < 4; i++)
			{
				this.CipherKeyIndexList.Add(i);
			}
			if (this.CipherKeyList == null)
			{
				this.CipherKeyList = new List<CipherKey>();
			}
			this.CipherKeyList.Clear();
			this.CanConfirm = true;
		}

		// Token: 0x06044F27 RID: 282407 RVA: 0x011F23E9 File Offset: 0x011F05E9
		protected override void OnStart()
		{
			this.OnKeySelectedHandle = new Action<int, int>(this.KeySelectedHandle);
			this.PasswordPanel = new GenericLayoutNew<CipherKey>(base.GetHorizontalLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CipherKey>(this.CreateCipherKeyItem), null);
		}

		// Token: 0x06044F28 RID: 282408 RVA: 0x011F241C File Offset: 0x011F061C
		protected override void OnAfterShow()
		{
			this.PasswordPanel.RebuildLayoutByDataNew<int>(this.CipherKeyIndexList, null);
			for (int i = 0; i < 4; i++)
			{
				this.KeySelectedHandle(i, 0);
			}
		}

		// Token: 0x06044F29 RID: 282409 RVA: 0x011F2457 File Offset: 0x011F0657
		protected override void OnAfterHide()
		{
			this.PasswordPanel.ClearChildren();
			if (!this.CanConfirm)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("CipherConfirmClick", false);
			}
		}

		// Token: 0x06044F2A RID: 282410 RVA: 0x011F247C File Offset: 0x011F067C
		protected override void OnBeforeDestroy()
		{
			if (TimerSystem.Instance.Has(this.CorrectTimerId))
			{
				TimerSystem.Instance.Remove(this.CorrectTimerId);
			}
			if (TimerSystem.Instance.Has(this.WrongTimerId))
			{
				TimerSystem.Instance.Remove(this.WrongTimerId);
			}
		}

		// Token: 0x06044F2B RID: 282411 RVA: 0x011F24CF File Offset: 0x011F06CF
		protected override void OnAddEventListener()
		{
			base.GetButton(0).OnClickCallBack.Bind(new Action(this.OnCloseClick));
			base.GetButton(1).OnClickCallBack.Bind(new Action(this.OnConfirmClick));
		}

		// Token: 0x06044F2C RID: 282412 RVA: 0x011F250B File Offset: 0x011F070B
		protected override void OnRemoveEventListener()
		{
			base.GetButton(0).OnClickCallBack.Unbind();
			base.GetButton(1).OnClickCallBack.Unbind();
		}

		// Token: 0x06044F2D RID: 282413 RVA: 0x011F2530 File Offset: 0x011F0730
		private ILayoutItem<CipherKey> CreateCipherKeyItem(object data, UUIItem uiItem, int index)
		{
			CipherKey cipherKey = new CipherKey(uiItem, index);
			cipherKey.InitKey(this.OnKeySelectedHandle);
			this.CipherKeyList.Add(cipherKey);
			return new LayoutItem<CipherKey>
			{
				Key = index,
				Value = cipherKey
			};
		}

		// Token: 0x06044F2E RID: 282414 RVA: 0x011F2575 File Offset: 0x011F0775
		public void OnCloseClick()
		{
			if (!this.CanConfirm)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("CipherConfirmClick", false);
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CipherView, null);
		}

		// Token: 0x06044F2F RID: 282415 RVA: 0x011F25A0 File Offset: 0x011F07A0
		public void OnConfirmClick()
		{
			if (!this.CanConfirm)
			{
				return;
			}
			int num = 1500;
			int num2 = 1500;
			bool flag = ModelBase<CipherModel>.Instance.IsPasswordCorrect();
			int index = 0;
			Singleton<UiLayer>.Instance.SetShowMaskLayer("CipherConfirmClick", true);
			foreach (CipherKey cipherKey in this.CipherKeyList)
			{
				bool checkResultByIndex = ModelBase<CipherModel>.Instance.GetCheckResultByIndex(index);
				cipherKey.HandleConfirm(checkResultByIndex);
				this.HandleEffect(index, checkResultByIndex, false);
				int index3 = index;
				index = index3 + 1;
			}
			base.GetButton(1).SetEnable(false);
			this.CanConfirm = false;
			if (flag)
			{
				this.CorrectTimerId = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TriggerInteraction();
					Singleton<UiManager>.Instance.CloseView(EUiViewName.CipherView, null);
					Singleton<UiLayer>.Instance.SetShowMaskLayer("CipherConfirmClick", false);
				}, (float)num, null, null, true, 1f);
				Singleton<AudioSystem>.Instance.PostEvent("ui_cipher_confirm_success");
				return;
			}
			this.WrongTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.GetButton(1).SetEnable(true);
				index = 0;
				foreach (CipherKey cipherKey2 in this.CipherKeyList)
				{
					bool checkResultByIndex2 = ModelBase<CipherModel>.Instance.GetCheckResultByIndex(index);
					if (!checkResultByIndex2)
					{
						cipherKey2.HandleRest();
					}
					this.HandleEffect(index, checkResultByIndex2, true);
					int index2 = index;
					index = index2 + 1;
				}
				this.CanConfirm = true;
				Singleton<UiLayer>.Instance.SetShowMaskLayer("CipherConfirmClick", false);
			}, (float)num2, null, null, true, 1f);
			Singleton<AudioSystem>.Instance.PostEvent("ui_cipher_confirm_failure");
		}

		// Token: 0x06044F30 RID: 282416 RVA: 0x011F26F0 File Offset: 0x011F08F0
		public void TriggerInteraction()
		{
			ControllerBase<CipherController>.Instance.RequestCipherComplete();
		}

		// Token: 0x06044F31 RID: 282417 RVA: 0x011F26FC File Offset: 0x011F08FC
		private void HandleEffect(int inIndex, bool inResult, bool inIsRest)
		{
			int num = -1;
			int num2 = 0;
			if (inResult)
			{
				num = 1;
				num2 = 1;
			}
			if (inResult && inIsRest)
			{
				return;
			}
			if (inIsRest)
			{
				num = 0;
			}
			switch (inIndex)
			{
			case 0:
				base.GetUiNiagara(3).SetNiagaraVarFloat("TargetTime", (float)num);
				base.GetUiNiagara(3).SetNiagaraVarFloat("Flag", (float)num2);
				return;
			case 1:
				base.GetUiNiagara(4).SetNiagaraVarFloat("TargetTime", (float)num);
				base.GetUiNiagara(4).SetNiagaraVarFloat("Flag", (float)num2);
				return;
			case 2:
				base.GetUiNiagara(5).SetNiagaraVarFloat("TargetTime", (float)num);
				base.GetUiNiagara(5).SetNiagaraVarFloat("Flag", (float)num2);
				return;
			case 3:
				base.GetUiNiagara(6).SetNiagaraVarFloat("TargetTime", (float)num);
				base.GetUiNiagara(6).SetNiagaraVarFloat("Flag", (float)num2);
				return;
			default:
				return;
			}
		}

		// Token: 0x06044F32 RID: 282418 RVA: 0x011F27D4 File Offset: 0x011F09D4
		private void KeySelectedHandle(int index, int value)
		{
			float value2 = Singleton<MathUtils>.Instance.RangeClamp((float)value, 0f, 9f, 0.1f, 1.5f);
			switch (index)
			{
			case 0:
				base.GetUiNiagara(3).SetNiagaraVarFloat("WPO", value2);
				break;
			case 1:
				base.GetUiNiagara(4).SetNiagaraVarFloat("WPO", value2);
				break;
			case 2:
				base.GetUiNiagara(5).SetNiagaraVarFloat("WPO", value2);
				break;
			case 3:
				base.GetUiNiagara(6).SetNiagaraVarFloat("WPO", value2);
				break;
			}
			Singleton<AudioSystem>.Instance.PostEvent("ui_cipher_picker_select");
		}

		// Token: 0x0402671D RID: 157469
		private const int WRONG_COLOR = -1;

		// Token: 0x0402671E RID: 157470
		private const int RIGHT_COLOR = 1;

		// Token: 0x0402671F RID: 157471
		private const int NORMAL_COLOR = 0;

		// Token: 0x04026720 RID: 157472
		private const string WPO = "WPO";

		// Token: 0x04026721 RID: 157473
		private const string COLOR = "TargetTime";

		// Token: 0x04026722 RID: 157474
		private const string FLAG = "Flag";

		// Token: 0x04026723 RID: 157475
		private const int LEN = 4;

		// Token: 0x04026724 RID: 157476
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<CipherKey> PasswordPanel;

		// Token: 0x04026725 RID: 157477
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<CipherKey> CipherKeyList;

		// Token: 0x04026726 RID: 157478
		[Nullable(2)]
		private List<int> CipherKeyIndexList;

		// Token: 0x04026727 RID: 157479
		[Nullable(2)]
		public TimerHandle CorrectTimerId;

		// Token: 0x04026728 RID: 157480
		[Nullable(2)]
		private TimerHandle WrongTimerId;

		// Token: 0x04026729 RID: 157481
		private bool CanConfirm;

		// Token: 0x0402672A RID: 157482
		[Nullable(2)]
		protected Action<int, int> OnKeySelectedHandle;

		// Token: 0x0200CBE2 RID: 52194
		[NullableContext(0)]
		private class ECipherView
		{
			// Token: 0x0403E86C RID: 256108
			public const int Close = 0;

			// Token: 0x0403E86D RID: 256109
			public const int Confirm = 1;

			// Token: 0x0403E86E RID: 256110
			public const int PasswordPanel = 2;

			// Token: 0x0403E86F RID: 256111
			public const int Effect1 = 3;

			// Token: 0x0403E870 RID: 256112
			public const int Effect2 = 4;

			// Token: 0x0403E871 RID: 256113
			public const int Effect3 = 5;

			// Token: 0x0403E872 RID: 256114
			public const int Effect4 = 6;
		}
	}
}
