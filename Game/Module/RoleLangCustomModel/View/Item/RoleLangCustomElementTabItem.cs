using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel.View.Item
{
	// Token: 0x020050F8 RID: 20728
	public class RoleLangCustomElementTabItem : GridProxyAbstract<int>
	{
		// Token: 0x060356F4 RID: 218868 RVA: 0x00D68B08 File Offset: 0x00D66D08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060356F5 RID: 218869 RVA: 0x00D68BD4 File Offset: 0x00D66DD4
		protected override void OnStart()
		{
			base.GetExtendToggle(1).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x060356F6 RID: 218870 RVA: 0x00D68BF4 File Offset: 0x00D66DF4
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.CurElementId = data;
			if (data == 0)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TutorialIconAll");
				this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
			}
			else
			{
				string spriteIcon = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(data).Value.SpriteIcon1;
				this.SetSpriteByPath(spriteIcon, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
			}
			if (this.OnToggleSelectedCheck != null)
			{
				this.SetSelected(this.OnToggleSelectedCheck(data), false);
			}
		}

		// Token: 0x060356F7 RID: 218871 RVA: 0x00D68CA0 File Offset: 0x00D66EA0
		protected void RefreshTransition(bool _)
		{
			UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
			if (uiExtendToggleSpriteTransition != null)
			{
				uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
			}
		}

		// Token: 0x060356F8 RID: 218872 RVA: 0x00D68CCA File Offset: 0x00D66ECA
		public void RefreshSelected()
		{
			if (this.OnToggleSelectedCheck != null)
			{
				this.SetSelected(this.OnToggleSelectedCheck(this.CurElementId), false);
			}
		}

		// Token: 0x060356F9 RID: 218873 RVA: 0x00D68CEC File Offset: 0x00D66EEC
		public void SetSelected(bool isSelected, bool fireEvent = false)
		{
			base.GetExtendToggle(1).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x060356FA RID: 218874 RVA: 0x00D68D05 File Offset: 0x00D66F05
		private void OnToggleStateChanged(EToggleState state)
		{
			Action<int> onToggleStateChangedCallback = this.OnToggleStateChangedCallback;
			if (onToggleStateChangedCallback == null)
			{
				return;
			}
			onToggleStateChangedCallback(this.CurElementId);
		}

		// Token: 0x0401EB0F RID: 125711
		private const int FILTER_ALL_ID = 0;

		// Token: 0x0401EB10 RID: 125712
		protected int CurElementId;

		// Token: 0x0401EB11 RID: 125713
		[Nullable(1)]
		public Action<int> OnToggleStateChangedCallback;

		// Token: 0x0401EB12 RID: 125714
		[Nullable(1)]
		public Func<int, bool> OnToggleSelectedCheck;

		// Token: 0x0200B096 RID: 45206
		private enum EDefine
		{
			// Token: 0x04036CAA RID: 224426
			SpriteIcon,
			// Token: 0x04036CAB RID: 224427
			TogItem,
			// Token: 0x04036CAC RID: 224428
			RedDot,
			// Token: 0x04036CAD RID: 224429
			SpriteIcon2,
			// Token: 0x04036CAE RID: 224430
			SpriteSubIcon
		}
	}
}
