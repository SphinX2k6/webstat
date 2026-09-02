using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View.Item
{
	// Token: 0x020050FB RID: 20731
	public class RoleLangCustomFilterTabItem : GridProxyAbstract<int>
	{
		// Token: 0x06035715 RID: 218901 RVA: 0x00D698C4 File Offset: 0x00D67AC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035716 RID: 218902 RVA: 0x00D699F4 File Offset: 0x00D67BF4
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x06035717 RID: 218903 RVA: 0x00D69A54 File Offset: 0x00D67C54
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			if (data < 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Btn_VoiceDIY_Filter_All", Array.Empty<object>());
			}
			else
			{
				RoleVoiceLanguage? roleLangCustomConfigById = ConfigBase<MenuBaseConfig>.Instance.GetRoleLangCustomConfigById(data);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleLangCustomConfigById.Value.Text, Array.Empty<object>());
			}
			if (this.CheckIsSelected != null)
			{
				EToggleState state = this.CheckIsSelected(data) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(state, false, false, false);
			}
		}

		// Token: 0x06035718 RID: 218904 RVA: 0x00D69AEB File Offset: 0x00D67CEB
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<int> onClickedCallback = this.OnClickedCallback;
			if (onClickedCallback == null)
			{
				return;
			}
			onClickedCallback(this.ItemData);
		}

		// Token: 0x0401EB1D RID: 125725
		[Nullable(2)]
		public Func<int, bool> CheckIsSelected;

		// Token: 0x0401EB1E RID: 125726
		[Nullable(2)]
		public Action<int> OnClickedCallback;

		// Token: 0x0401EB1F RID: 125727
		protected int ItemData;

		// Token: 0x0200B09B RID: 45211
		private enum EToggle
		{
			// Token: 0x04036CD0 RID: 224464
			ToggleItem,
			// Token: 0x04036CD1 RID: 224465
			TxtName,
			// Token: 0x04036CD2 RID: 224466
			PanelCheckState,
			// Token: 0x04036CD3 RID: 224467
			BtnDownloadProgress,
			// Token: 0x04036CD4 RID: 224468
			SpriteDownloadFill,
			// Token: 0x04036CD5 RID: 224469
			SpritePauseIcon,
			// Token: 0x04036CD6 RID: 224470
			SpritePlayIcon,
			// Token: 0x04036CD7 RID: 224471
			BtnDownload
		}
	}
}
