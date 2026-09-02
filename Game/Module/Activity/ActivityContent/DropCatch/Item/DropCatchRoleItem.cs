using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068F3 RID: 26867
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropCatchRoleItem : GridProxyAbstract<IDropCatchRoleItemData>
	{
		// Token: 0x06042C16 RID: 273430 RVA: 0x01121A5C File Offset: 0x0111FC5C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClicked))
			};
		}

		// Token: 0x06042C17 RID: 273431 RVA: 0x01121B34 File Offset: 0x0111FD34
		public override void Refresh(IDropCatchRoleItemData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.CfgId = data.RoleCfgId;
			this.BookCfgId = data.BookCfgId;
			this.IsUnlock = data.IsUnlock;
			this.SetToggleSelect(isSelected);
			DropCatchRole? dropCatchRoleById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchRoleById(this.CfgId);
			if (dropCatchRoleById != null)
			{
				UUITexture texture = base.GetTexture(2);
				if (texture != null)
				{
					texture.SetUIActive(this.IsUnlock);
				}
				UUITexture texture2 = base.GetTexture(3);
				if (texture2 != null)
				{
					texture2.SetUIActive(!this.IsUnlock);
				}
				if (this.IsUnlock)
				{
					base.SetTextureByPath(dropCatchRoleById.Value.RoleTexturePath, base.GetTexture(2), null, null);
					UUIText text = base.GetText(1);
					if (text != null)
					{
						text.ShowTextNew(dropCatchRoleById.Value.Name);
					}
				}
				else
				{
					base.SetTextureByPath(dropCatchRoleById.Value.SilhouettePath, base.GetTexture(6), null, null);
					UUIText text2 = base.GetText(1);
					if (text2 != null)
					{
						text2.ShowTextNew("CoinCatch_Character_UnlockName");
					}
				}
			}
			string text3 = (gridIndex + 1).ToString();
			this.SetSpriteByPath(StringUtils.Format("/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}", new string[]
			{
				text3,
				text3
			}), base.GetSprite(4), false, null, null);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!this.IsUnlock);
			}
			bool uiactive = this.IsUnlock && ControllerBase<DropCatchActivityController>.Instance.IsNewRoleClicked(this.CfgId);
			UUIItem item2 = base.GetItem(5);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive);
		}

		// Token: 0x06042C18 RID: 273432 RVA: 0x01121CD7 File Offset: 0x0111FED7
		public void SetClickCallback(Action<int, int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06042C19 RID: 273433 RVA: 0x01121CE0 File Offset: 0x0111FEE0
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleSelect(true);
		}

		// Token: 0x06042C1A RID: 273434 RVA: 0x01121CE9 File Offset: 0x0111FEE9
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleSelect(false);
		}

		// Token: 0x06042C1B RID: 273435 RVA: 0x01121CF4 File Offset: 0x0111FEF4
		private void OnClicked(EToggleState state)
		{
			if (this.IsUnlock)
			{
				ControllerBase<DropCatchActivityController>.Instance.SetNewRoleClicked(this.CfgId);
				bool uiactive = ControllerBase<DropCatchActivityController>.Instance.IsNewRoleClicked(this.CfgId);
				UUIItem item = base.GetItem(5);
				if (item != null)
				{
					item.SetUIActive(uiactive);
				}
			}
			Action<int, int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.BookCfgId, base.GridIndex);
		}

		// Token: 0x06042C1C RID: 273436 RVA: 0x01121D59 File Offset: 0x0111FF59
		public void SetToggleSelect(bool select)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0402531B RID: 152347
		private int CfgId;

		// Token: 0x0402531C RID: 152348
		private int BookCfgId;

		// Token: 0x0402531D RID: 152349
		private bool IsUnlock;

		// Token: 0x0402531E RID: 152350
		private Action<int, int> ClickCallback = delegate(int configId, int index)
		{
		};

		// Token: 0x0402531F RID: 152351
		private const string ROME_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Atlas/Num/Roman/RomanB/SP_RomanA0{0}.SP_RomanA0{1}";
	}
}
