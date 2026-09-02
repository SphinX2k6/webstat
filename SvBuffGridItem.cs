using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001216 RID: 4630
[NullableContext(2)]
[Nullable(0)]
public class SvBuffGridItem : GridProxyAbstract<int>
{
	// Token: 0x06007AE7 RID: 31463 RVA: 0x00201ED4 File Offset: 0x002000D4
	[NullableContext(1)]
	public void SetParentItem(MutexGroupItem parent)
	{
		this.ParentItem = parent;
	}

	// Token: 0x06007AE8 RID: 31464 RVA: 0x00201EE0 File Offset: 0x002000E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007AE9 RID: 31465 RVA: 0x00201F8C File Offset: 0x0020018C
	protected override UniTask OnBeforeStartAsync()
	{
		SvBuffGridItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SvBuffGridItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007AEA RID: 31466 RVA: 0x00201FD0 File Offset: 0x002001D0
	protected override void OnStart()
	{
		ComBuffSubComponent comBuffIns = this.ComBuffIns;
		if (comBuffIns != null)
		{
			comBuffIns.SetActive(true);
		}
		ComBuffSubComponent comBuffIns2 = this.ComBuffIns;
		UUIExtendToggle uuiextendToggle = (comBuffIns2 != null) ? comBuffIns2.GetBuffToggle() : null;
		if (uuiextendToggle != null)
		{
			uuiextendToggle.CanExecuteChange.Bind(delegate()
			{
				MutexGroupItem parentItem = this.ParentItem;
				if (parentItem != null && parentItem.IsQuickSelectMode())
				{
					BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
					{
						IsDeTerm = true,
						ConfigId = this.BuffId,
						ShowWays = false
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
					return false;
				}
				return this.CanClickCallBack == null || this.CanClickCallBack();
			});
			uuiextendToggle.OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
			uuiextendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		}
	}

	// Token: 0x06007AEB RID: 31467 RVA: 0x0020204C File Offset: 0x0020024C
	private void OnToggleStateChange(EToggleState state)
	{
		if (this.IsSuppressToggleCallback)
		{
			return;
		}
		if (state == EToggleState.ETT_Checked)
		{
			Action<int, UUIExtendToggle> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			int buffId = this.BuffId;
			ComBuffSubComponent comBuffIns = this.ComBuffIns;
			onClickCallBack(buffId, (comBuffIns != null) ? comBuffIns.GetBuffToggle() : null);
			return;
		}
		else
		{
			Action<int, UUIExtendToggle> onClickCallBack2 = this.OnClickCallBack;
			if (onClickCallBack2 == null)
			{
				return;
			}
			onClickCallBack2(0, null);
			return;
		}
	}

	// Token: 0x06007AEC RID: 31468 RVA: 0x002020A4 File Offset: 0x002002A4
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.BuffId = data;
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		if (gridIndex % 3 == 2)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
		}
		MutexGroupItem parentItem = this.ParentItem;
		bool flag = parentItem != null && parentItem.GetIsNecessary();
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		if (data <= 0)
		{
			ComBuffSubComponent comBuffIns = this.ComBuffIns;
			if (comBuffIns != null)
			{
				comBuffIns.SetLockActive(true);
			}
			ComBuffSubComponent comBuffIns2 = this.ComBuffIns;
			if (comBuffIns2 == null)
			{
				return;
			}
			comBuffIns2.SetToggleVisible(false);
			return;
		}
		else
		{
			BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(data);
			ComBuffSubComponent comBuffIns3 = this.ComBuffIns;
			if (comBuffIns3 != null)
			{
				comBuffIns3.SetTextureByPath(babelTowerDeTerm.Texture);
			}
			IBabelTowerSelectInfo valueOrDefault = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.GetValueOrDefault(data);
			ComBuffSubComponent comBuffIns4 = this.ComBuffIns;
			if (comBuffIns4 == null)
			{
				return;
			}
			comBuffIns4.SetLockActive(valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.Lock);
			return;
		}
	}

	// Token: 0x06007AED RID: 31469 RVA: 0x0020219B File Offset: 0x0020039B
	[NullableContext(1)]
	public void SetCanClickCallBack(Func<bool> callback)
	{
		this.CanClickCallBack = callback;
	}

	// Token: 0x06007AEE RID: 31470 RVA: 0x002021A4 File Offset: 0x002003A4
	private void OnUndeterminedClicked()
	{
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = true,
			ConfigId = this.BuffId,
			ShowWays = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x06007AEF RID: 31471 RVA: 0x002021E4 File Offset: 0x002003E4
	public void SetToggleState(EToggleState state)
	{
		ComBuffSubComponent comBuffIns = this.ComBuffIns;
		UUIExtendToggle uuiextendToggle = (comBuffIns != null) ? comBuffIns.GetBuffToggle() : null;
		if (uuiextendToggle != null)
		{
			bool isSuppressToggleCallback = this.IsSuppressToggleCallback;
			this.IsSuppressToggleCallback = true;
			uuiextendToggle.SetToggleStateForce(state, false, false, false);
			this.IsSuppressToggleCallback = isSuppressToggleCallback;
		}
	}

	// Token: 0x06007AF0 RID: 31472 RVA: 0x00202226 File Offset: 0x00200426
	public void SuppressToggleCallback(bool suppress)
	{
		this.IsSuppressToggleCallback = suppress;
	}

	// Token: 0x06007AF1 RID: 31473 RVA: 0x0020222F File Offset: 0x0020042F
	public void UseChangeColor(bool use)
	{
		ComBuffSubComponent comBuffIns = this.ComBuffIns;
		if (comBuffIns == null)
		{
			return;
		}
		comBuffIns.UseChangeColor(use);
	}

	// Token: 0x06007AF2 RID: 31474 RVA: 0x00202242 File Offset: 0x00200442
	public void FlashHighlight()
	{
		ComBuffSubComponent comBuffIns = this.ComBuffIns;
		if (comBuffIns == null)
		{
			return;
		}
		comBuffIns.FlashHighlight();
	}

	// Token: 0x04003AF2 RID: 15090
	public int BuffId;

	// Token: 0x04003AF3 RID: 15091
	public Action<int, UUIExtendToggle> OnClickCallBack;

	// Token: 0x04003AF4 RID: 15092
	private Func<bool> CanClickCallBack;

	// Token: 0x04003AF5 RID: 15093
	private MutexGroupItem ParentItem;

	// Token: 0x04003AF6 RID: 15094
	private ComBuffSubComponent ComBuffIns;

	// Token: 0x04003AF7 RID: 15095
	public bool IsSuppressToggleCallback;

	// Token: 0x0200756F RID: 30063
	[NullableContext(0)]
	private class EItemGroupSubComponent
	{
		// Token: 0x04028844 RID: 165956
		public const int ComBuff = 0;

		// Token: 0x04028845 RID: 165957
		public const int LineSprite = 1;

		// Token: 0x04028846 RID: 165958
		public const int Check = 2;

		// Token: 0x04028847 RID: 165959
		public const int Lock = 3;
	}
}
