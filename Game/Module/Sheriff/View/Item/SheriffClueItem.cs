using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FEC RID: 20460
	[NullableContext(2)]
	[Nullable(0)]
	public class SheriffClueItem : GridProxyAbstract<int>
	{
		// Token: 0x06034BEA RID: 216042 RVA: 0x00D3BB0B File Offset: 0x00D39D0B
		[NullableContext(1)]
		public SheriffClueItem(SheriffMainProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06034BEB RID: 216043 RVA: 0x00D3BB1C File Offset: 0x00D39D1C
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnCommon));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034BEC RID: 216044 RVA: 0x00D3BC48 File Offset: 0x00D39E48
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
			base.GetExtendToggle(0).OnHover.Add(new Action(this.OnHoverItem));
		}

		// Token: 0x06034BED RID: 216045 RVA: 0x00D3BCAC File Offset: 0x00D39EAC
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChanged));
				extendToggle.CanExecuteChange.Unbind();
				extendToggle.OnHover.Remove(new Action(this.OnHoverItem));
			}
		}

		// Token: 0x06034BEE RID: 216046 RVA: 0x00D3BD00 File Offset: 0x00D39F00
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.CurId = data;
			base.GetItem(3).SetUIActive(data <= 0);
			if (data <= 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Inference_Desc_6", Array.Empty<object>());
				UUITexture texture = base.GetTexture(2);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
			}
			else
			{
				SheriffClue? clueConfigById = ConfigBase<SheriffConfig>.Instance.GetClueConfigById(data);
				if (clueConfigById == null)
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), clueConfigById.Value.Name, Array.Empty<object>());
				UUITexture texture2 = base.GetTexture(2);
				if (texture2 != null)
				{
					texture2.SetUIActive(true);
				}
				base.SetTextureByPath(clueConfigById.Value.Icon, base.GetTexture(2), null, null);
			}
			bool flag = true;
			if (this.CheckSelectCallback != null)
			{
				EToggleState etoggleState = this.CheckSelectCallback(gridIndex);
				this.SetSelected(etoggleState, true);
				flag = (etoggleState != EToggleState.ETT_UnDetermined);
			}
			base.GetItem(5).SetUIActive(flag && this.Proxy.CheckIsHinting(this.CurId));
		}

		// Token: 0x06034BEF RID: 216047 RVA: 0x00D3BE1C File Offset: 0x00D3A01C
		public void RefreshSelected()
		{
			if (this.CheckSelectCallback != null)
			{
				this.SetSelected(this.CheckSelectCallback(base.GridIndex), false);
			}
		}

		// Token: 0x06034BF0 RID: 216048 RVA: 0x00D3BE3E File Offset: 0x00D3A03E
		protected void SetSelected(EToggleState state, bool jumpToLastFrame = true)
		{
			base.GetExtendToggle(0).SetActive(state != EToggleState.ETT_UnDetermined, false);
			base.GetExtendToggle(0).SetToggleState(state, false, false, jumpToLastFrame);
		}

		// Token: 0x06034BF1 RID: 216049 RVA: 0x00D3BE65 File Offset: 0x00D3A065
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<int, bool> onToggleStateChangedCallback = this.OnToggleStateChangedCallback;
			if (onToggleStateChangedCallback == null)
			{
				return;
			}
			onToggleStateChangedCallback(this.CurId, state == EToggleState.ETT_Checked);
		}

		// Token: 0x06034BF2 RID: 216050 RVA: 0x00D3BE84 File Offset: 0x00D3A084
		private bool OnCanExecuteChange()
		{
			EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
			Func<int, EToggleState, bool> checkCanChangeCallback = this.CheckCanChangeCallback;
			return checkCanChangeCallback == null || checkCanChangeCallback(this.CurId, toggleState);
		}

		// Token: 0x06034BF3 RID: 216051 RVA: 0x00D3BEB6 File Offset: 0x00D3A0B6
		private void OnHoverItem()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.Proxy.OnHoverClue(base.GridIndex);
			}
		}

		// Token: 0x06034BF4 RID: 216052 RVA: 0x00D3BED5 File Offset: 0x00D3A0D5
		private void OnClickBtnCommon()
		{
			this.Proxy.ClickClueDetail(base.GridIndex);
		}

		// Token: 0x06034BF5 RID: 216053 RVA: 0x00D3BEE8 File Offset: 0x00D3A0E8
		public UUIItem GetGuideMagnifierItem()
		{
			UUIButtonComponent button = base.GetButton(4);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x0401E644 RID: 124484
		protected int CurId;

		// Token: 0x0401E645 RID: 124485
		[Nullable(1)]
		protected SheriffMainProxy Proxy;

		// Token: 0x0401E646 RID: 124486
		public Action<int, bool> OnToggleStateChangedCallback;

		// Token: 0x0401E647 RID: 124487
		public Func<int, EToggleState, bool> CheckCanChangeCallback;

		// Token: 0x0401E648 RID: 124488
		public Func<int, EToggleState> CheckSelectCallback;

		// Token: 0x0401E649 RID: 124489
		public Func<bool> CheckToggleEnable;

		// Token: 0x0200AFC7 RID: 44999
		[NullableContext(0)]
		private static class EClueItem
		{
			// Token: 0x040368AC RID: 223404
			public const int Tog = 0;

			// Token: 0x040368AD RID: 223405
			public const int TxtName = 1;

			// Token: 0x040368AE RID: 223406
			public const int TxtIcon = 2;

			// Token: 0x040368AF RID: 223407
			public const int PanelLock = 3;

			// Token: 0x040368B0 RID: 223408
			public const int BtnCommon = 4;

			// Token: 0x040368B1 RID: 223409
			public const int PanelHint = 5;
		}
	}
}
