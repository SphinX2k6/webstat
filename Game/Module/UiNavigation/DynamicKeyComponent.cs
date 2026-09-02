using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CF5 RID: 19701
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicKeyComponent : UiPanelBase
	{
		// Token: 0x060333F0 RID: 209904 RVA: 0x00CD49FA File Offset: 0x00CD2BFA
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x060333F1 RID: 209905 RVA: 0x00CD4A34 File Offset: 0x00CD2C34
		protected override UniTask OnBeforeStartAsync()
		{
			DynamicKeyComponent.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DynamicKeyComponent.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060333F2 RID: 209906 RVA: 0x00CD4A77 File Offset: 0x00CD2C77
		public void SetKeyName(string keyName)
		{
			this.KeyName = keyName;
		}

		// Token: 0x060333F3 RID: 209907 RVA: 0x00CD4A80 File Offset: 0x00CD2C80
		public void SetIsNeedLongPress(bool isLongPress)
		{
			this.IsLongPress = isLongPress;
		}

		// Token: 0x060333F4 RID: 209908 RVA: 0x00CD4A89 File Offset: 0x00CD2C89
		public void RefreshKeyIcon(string keyName)
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.RefreshKeyIcon(keyName);
		}

		// Token: 0x060333F5 RID: 209909 RVA: 0x00CD4A9C File Offset: 0x00CD2C9C
		public void RefreshNameText(string textId)
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.RefreshNameText(textId);
		}

		// Token: 0x060333F6 RID: 209910 RVA: 0x00CD4AAF File Offset: 0x00CD2CAF
		public void RefreshPcAndGamepad()
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.RefreshPcAndGamepad();
		}

		// Token: 0x060333F7 RID: 209911 RVA: 0x00CD4AC1 File Offset: 0x00CD2CC1
		public void SetNameText(string keyText)
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.SetNameText(keyText);
		}

		// Token: 0x060333F8 RID: 209912 RVA: 0x00CD4AD4 File Offset: 0x00CD2CD4
		public void SetLongPressState(float percent)
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.SetLongPressState(percent);
		}

		// Token: 0x060333F9 RID: 209913 RVA: 0x00CD4AE7 File Offset: 0x00CD2CE7
		public void SetLongPressItemAlpha(float alpha)
		{
			KeyBaseComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.SetLongPressItemAlpha(alpha);
		}

		// Token: 0x0401DC33 RID: 121907
		private string KeyName = "";

		// Token: 0x0401DC34 RID: 121908
		private bool IsLongPress;

		// Token: 0x0401DC35 RID: 121909
		[Nullable(2)]
		protected KeyBaseComponent CurComponent;

		// Token: 0x0200AD52 RID: 44370
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035D7C RID: 220540
			public const int Text = 0;

			// Token: 0x04035D7D RID: 220541
			public const int KeyItem = 1;
		}
	}
}
