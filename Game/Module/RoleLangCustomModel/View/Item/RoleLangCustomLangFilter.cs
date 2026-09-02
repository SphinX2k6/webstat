using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View.Item
{
	// Token: 0x020050FA RID: 20730
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangCustomLangFilter : UiPanelBase
	{
		// Token: 0x06035708 RID: 218888 RVA: 0x00D694C8 File Offset: 0x00D676C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035709 RID: 218889 RVA: 0x00D695B8 File Offset: 0x00D677B8
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button2 = base.GetButton(3);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
			this.ScrollView = new GenericScrollViewNew<RoleLangCustomFilterTabItem, int>(base.GetScrollViewWithScrollbar(4), new Func<RoleLangCustomFilterTabItem>(this.CreateItem), null, false, null);
			List<int> roleLangCustomInfo = this.GetRoleLangCustomInfo();
			this.ScrollView.RefreshByData(roleLangCustomInfo, null, false);
			this.Refresh(-1);
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x0603570A RID: 218890 RVA: 0x00D69660 File Offset: 0x00D67860
		protected override void OnBeforeDestroy()
		{
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton != null)
			{
				maskButton.Destroy(null);
			}
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
			base.GetExtendToggle(0).OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x0603570B RID: 218891 RVA: 0x00D696B0 File Offset: 0x00D678B0
		public void Refresh(int data)
		{
			this.CurrentSelectedId = data;
			if (data < 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Btn_VoiceDIY_Filter_All", Array.Empty<object>());
			}
			else
			{
				RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(data);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleLangCustomConfigById.Value.Text, Array.Empty<object>());
			}
			List<int> roleLangCustomInfo = this.GetRoleLangCustomInfo();
			this.ScrollView.RefreshByData(roleLangCustomInfo, null, false);
		}

		// Token: 0x0603570C RID: 218892 RVA: 0x00D6972C File Offset: 0x00D6792C
		protected List<int> GetRoleLangCustomInfo()
		{
			List<int> list = new List<int>
			{
				-1
			};
			List<int> allLanguageTypeForAudio = Singleton<LanguageUpdateManager>.Instance.GetAllLanguageTypeForAudio();
			allLanguageTypeForAudio.Sort((int a, int b) => a - b);
			foreach (int item in allLanguageTypeForAudio)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603570D RID: 218893 RVA: 0x00D697B8 File Offset: 0x00D679B8
		private UniTask ShowMaskButton()
		{
			RoleLangCustomLangFilter.<ShowMaskButton>d__10 <ShowMaskButton>d__;
			<ShowMaskButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowMaskButton>d__.<>4__this = this;
			<ShowMaskButton>d__.<>1__state = -1;
			<ShowMaskButton>d__.<>t__builder.Start<RoleLangCustomLangFilter.<ShowMaskButton>d__10>(ref <ShowMaskButton>d__);
			return <ShowMaskButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603570E RID: 218894 RVA: 0x00D697FB File Offset: 0x00D679FB
		private void HideMaskButton()
		{
			if (this.MaskButton == null)
			{
				return;
			}
			this.MaskButton.ResetItemParent();
			this.MaskButton.SetActive(false);
		}

		// Token: 0x0603570F RID: 218895 RVA: 0x00D6981D File Offset: 0x00D67A1D
		private RoleLangCustomFilterTabItem CreateItem()
		{
			return new RoleLangCustomFilterTabItem
			{
				OnClickedCallback = new Action<int>(this.OnClickedToggleItem),
				CheckIsSelected = new Func<int, bool>(this.CheckIsSelected)
			};
		}

		// Token: 0x06035710 RID: 218896 RVA: 0x00D69848 File Offset: 0x00D67A48
		private void OnToggleStateChanged(EToggleState state)
		{
			this.ScrollView.SetActive(state == EToggleState.ETT_Checked);
			if (state == EToggleState.ETT_Checked)
			{
				this.ShowMaskButton();
				return;
			}
			this.HideMaskButton();
		}

		// Token: 0x06035711 RID: 218897 RVA: 0x00D6986B File Offset: 0x00D67A6B
		private void OnClickedToggleItem(int data)
		{
			this.Refresh(data);
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			Action<int> onToggleChange = this.OnToggleChange;
			if (onToggleChange == null)
			{
				return;
			}
			onToggleChange(data);
		}

		// Token: 0x06035712 RID: 218898 RVA: 0x00D69896 File Offset: 0x00D67A96
		private bool CheckIsSelected(int data)
		{
			return data == this.CurrentSelectedId;
		}

		// Token: 0x06035713 RID: 218899 RVA: 0x00D698A1 File Offset: 0x00D67AA1
		private void OnClickedMask()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
		}

		// Token: 0x0401EB19 RID: 125721
		protected GenericScrollViewNew<RoleLangCustomFilterTabItem, int> ScrollView;

		// Token: 0x0401EB1A RID: 125722
		[Nullable(2)]
		public Action<int> OnToggleChange;

		// Token: 0x0401EB1B RID: 125723
		protected int CurrentSelectedId = -1;

		// Token: 0x0401EB1C RID: 125724
		private DynamicMaskButton MaskButton;

		// Token: 0x0200B098 RID: 45208
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x04036CC3 RID: 224451
			TogSort,
			// Token: 0x04036CC4 RID: 224452
			TxtSort,
			// Token: 0x04036CC5 RID: 224453
			BtnInfo,
			// Token: 0x04036CC6 RID: 224454
			BtnSetting,
			// Token: 0x04036CC7 RID: 224455
			ScrollView,
			// Token: 0x04036CC8 RID: 224456
			ToggleItem
		}
	}
}
