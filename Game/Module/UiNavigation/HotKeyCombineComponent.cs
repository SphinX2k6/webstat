using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C80 RID: 19584
	[NullableContext(1)]
	[Nullable(0)]
	public class HotKeyCombineComponent
	{
		// Token: 0x060330C2 RID: 209090 RVA: 0x00CC9270 File Offset: 0x00CC7470
		public UniTask BeforeStartAsync(AActor rootActor)
		{
			HotKeyCombineComponent.<BeforeStartAsync>d__5 <BeforeStartAsync>d__;
			<BeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<BeforeStartAsync>d__.<>4__this = this;
			<BeforeStartAsync>d__.rootActor = rootActor;
			<BeforeStartAsync>d__.<>1__state = -1;
			<BeforeStartAsync>d__.<>t__builder.Start<HotKeyCombineComponent.<BeforeStartAsync>d__5>(ref <BeforeStartAsync>d__);
			return <BeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060330C3 RID: 209091 RVA: 0x00CC92BB File Offset: 0x00CC74BB
		public void SetConfig(HotKeyMap config)
		{
			this.Config = new HotKeyMap?(config);
		}

		// Token: 0x060330C4 RID: 209092 RVA: 0x00CC92C9 File Offset: 0x00CC74C9
		public void SetIsNeedLongPress(bool value)
		{
			this.IsLongPress = value;
		}

		// Token: 0x060330C5 RID: 209093 RVA: 0x00CC92D2 File Offset: 0x00CC74D2
		public void SetNeedRefreshKeyName(bool value)
		{
			this.NeedRefreshKeyName = value;
		}

		// Token: 0x060330C6 RID: 209094 RVA: 0x00CC92DC File Offset: 0x00CC74DC
		public void RefreshKeyIcon()
		{
			IReadOnlyList<string> keyNameList = this.GetKeyNameList();
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.RefreshKeyIcon((keyNameList.Count > 0) ? keyNameList[0] : null);
			}
			IconKeyComponent curComponent2 = this.CurComponent;
			if (curComponent2 != null)
			{
				curComponent2.SetActive(true);
			}
			this.RefreshDynamicKeyIconAsync(keyNameList).Forget();
		}

		// Token: 0x060330C7 RID: 209095 RVA: 0x00CC9334 File Offset: 0x00CC7534
		public void RefreshKeyIconWithoutActive()
		{
			IReadOnlyList<string> keyNameList = this.GetKeyNameList();
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.RefreshKeyIcon(keyNameList.GetValueOrDefault(0, string.Empty));
			}
			this.RefreshDynamicKeyIconAsync(keyNameList).Forget();
		}

		// Token: 0x060330C8 RID: 209096 RVA: 0x00CC9371 File Offset: 0x00CC7571
		public void SetVisible(bool value)
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.SetActive(value);
			}
			if (this.DynamicKeyComponent != null)
			{
				this.DynamicKeyComponent.SetActive(value);
			}
		}

		// Token: 0x060330C9 RID: 209097 RVA: 0x00CC939C File Offset: 0x00CC759C
		public void RefreshNameText(string textId)
		{
			DynamicKeyComponent dynamicKeyComponent = this.DynamicKeyComponent;
			if (dynamicKeyComponent != null && dynamicKeyComponent.IsShowOrShowing)
			{
				DynamicKeyComponent dynamicKeyComponent2 = this.DynamicKeyComponent;
				if (dynamicKeyComponent2 != null)
				{
					dynamicKeyComponent2.RefreshNameText(textId);
				}
				IconKeyComponent curComponent = this.CurComponent;
				if (curComponent == null)
				{
					return;
				}
				curComponent.RefreshNameText("");
				return;
			}
			else
			{
				IconKeyComponent curComponent2 = this.CurComponent;
				if (curComponent2 == null)
				{
					return;
				}
				curComponent2.RefreshNameText(textId);
				return;
			}
		}

		// Token: 0x060330CA RID: 209098 RVA: 0x00CC93F6 File Offset: 0x00CC75F6
		public bool GetIsForceSetText()
		{
			IconKeyComponent curComponent = this.CurComponent;
			return curComponent != null && curComponent.GetIsForceSetText();
		}

		// Token: 0x060330CB RID: 209099 RVA: 0x00CC9409 File Offset: 0x00CC7609
		public void RefreshPcAndGamepad()
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.RefreshPcAndGamepad();
			}
			if (this.DynamicKeyComponent != null)
			{
				this.DynamicKeyComponent.RefreshPcAndGamepad();
			}
		}

		// Token: 0x060330CC RID: 209100 RVA: 0x00CC9430 File Offset: 0x00CC7630
		public void SetNameText(string keyText)
		{
			DynamicKeyComponent dynamicKeyComponent = this.DynamicKeyComponent;
			if (dynamicKeyComponent != null && dynamicKeyComponent.IsShowOrShowing)
			{
				DynamicKeyComponent dynamicKeyComponent2 = this.DynamicKeyComponent;
				if (dynamicKeyComponent2 != null)
				{
					dynamicKeyComponent2.SetNameText(keyText);
				}
				IconKeyComponent curComponent = this.CurComponent;
				if (curComponent == null)
				{
					return;
				}
				curComponent.SetNameText("");
				return;
			}
			else
			{
				IconKeyComponent curComponent2 = this.CurComponent;
				if (curComponent2 == null)
				{
					return;
				}
				curComponent2.SetNameText(keyText);
				return;
			}
		}

		// Token: 0x060330CD RID: 209101 RVA: 0x00CC948A File Offset: 0x00CC768A
		public void SetNameTextForce(bool value)
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.SetNameTextForce(value);
		}

		// Token: 0x060330CE RID: 209102 RVA: 0x00CC949D File Offset: 0x00CC769D
		public void SetHotKeyType(HotKeyTypeBase hotKeyType)
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return;
			}
			curComponent.SetHotKeyType(hotKeyType);
		}

		// Token: 0x060330CF RID: 209103 RVA: 0x00CC94B0 File Offset: 0x00CC76B0
		[NullableContext(2)]
		public AActor GetRootActor()
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent == null)
			{
				return null;
			}
			return curComponent.GetRootActor();
		}

		// Token: 0x060330D0 RID: 209104 RVA: 0x00CC94C3 File Offset: 0x00CC76C3
		public void SetLongPressState(float percent)
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.SetLongPressState(percent);
			}
			if (this.DynamicKeyComponent != null)
			{
				this.DynamicKeyComponent.SetLongPressState(percent);
			}
		}

		// Token: 0x060330D1 RID: 209105 RVA: 0x00CC94EB File Offset: 0x00CC76EB
		public void SetLongPressItemAlpha(float alpha)
		{
			IconKeyComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.SetLongPressItemAlpha(alpha);
			}
			if (this.DynamicKeyComponent != null)
			{
				this.DynamicKeyComponent.SetLongPressItemAlpha(alpha);
			}
		}

		// Token: 0x060330D2 RID: 209106 RVA: 0x00CC9513 File Offset: 0x00CC7713
		private IReadOnlyList<string> GetKeyNameList()
		{
			if (!this.NeedRefreshKeyName)
			{
				return new <>z__ReadOnlySingleElementList<string>("");
			}
			if (this.Config == null)
			{
				return new <>z__ReadOnlySingleElementList<string>("");
			}
			return UiNavigationUtil.GetKeyNameListByConfig(this.Config.Value);
		}

		// Token: 0x060330D3 RID: 209107 RVA: 0x00CC9550 File Offset: 0x00CC7750
		private UniTask CreateCurComponent(string keyName, AActor rootActor)
		{
			HotKeyCombineComponent.<CreateCurComponent>d__22 <CreateCurComponent>d__;
			<CreateCurComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCurComponent>d__.<>4__this = this;
			<CreateCurComponent>d__.keyName = keyName;
			<CreateCurComponent>d__.rootActor = rootActor;
			<CreateCurComponent>d__.<>1__state = -1;
			<CreateCurComponent>d__.<>t__builder.Start<HotKeyCombineComponent.<CreateCurComponent>d__22>(ref <CreateCurComponent>d__);
			return <CreateCurComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060330D4 RID: 209108 RVA: 0x00CC95A4 File Offset: 0x00CC77A4
		private UniTask CreateDynamicComponent(string keyName)
		{
			HotKeyCombineComponent.<CreateDynamicComponent>d__23 <CreateDynamicComponent>d__;
			<CreateDynamicComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDynamicComponent>d__.<>4__this = this;
			<CreateDynamicComponent>d__.keyName = keyName;
			<CreateDynamicComponent>d__.<>1__state = -1;
			<CreateDynamicComponent>d__.<>t__builder.Start<HotKeyCombineComponent.<CreateDynamicComponent>d__23>(ref <CreateDynamicComponent>d__);
			return <CreateDynamicComponent>d__.<>t__builder.Task;
		}

		// Token: 0x060330D5 RID: 209109 RVA: 0x00CC95F0 File Offset: 0x00CC77F0
		private UniTask RefreshDynamicKeyIconAsync(IReadOnlyList<string> keyNameList)
		{
			HotKeyCombineComponent.<RefreshDynamicKeyIconAsync>d__24 <RefreshDynamicKeyIconAsync>d__;
			<RefreshDynamicKeyIconAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDynamicKeyIconAsync>d__.<>4__this = this;
			<RefreshDynamicKeyIconAsync>d__.keyNameList = keyNameList;
			<RefreshDynamicKeyIconAsync>d__.<>1__state = -1;
			<RefreshDynamicKeyIconAsync>d__.<>t__builder.Start<HotKeyCombineComponent.<RefreshDynamicKeyIconAsync>d__24>(ref <RefreshDynamicKeyIconAsync>d__);
			return <RefreshDynamicKeyIconAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401DAFB RID: 121595
		[Nullable(2)]
		protected IconKeyComponent CurComponent;

		// Token: 0x0401DAFC RID: 121596
		[Nullable(2)]
		protected DynamicKeyComponent DynamicKeyComponent;

		// Token: 0x0401DAFD RID: 121597
		protected bool IsLongPress;

		// Token: 0x0401DAFE RID: 121598
		protected bool NeedRefreshKeyName = true;

		// Token: 0x0401DAFF RID: 121599
		protected HotKeyMap? Config;
	}
}
