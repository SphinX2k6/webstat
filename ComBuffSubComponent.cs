using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001217 RID: 4631
public class ComBuffSubComponent : UiPanelBase
{
	// Token: 0x06007AF6 RID: 31478 RVA: 0x002022D0 File Offset: 0x002004D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007AF7 RID: 31479 RVA: 0x002023C0 File Offset: 0x002005C0
	protected override UniTask OnBeforeStartAsync()
	{
		ComBuffSubComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ComBuffSubComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007AF8 RID: 31480 RVA: 0x00202403 File Offset: 0x00200603
	protected override void OnStart()
	{
		base.SetUiActive(true);
	}

	// Token: 0x06007AF9 RID: 31481 RVA: 0x0020240C File Offset: 0x0020060C
	[NullableContext(2)]
	public UUIExtendToggle GetBuffToggle()
	{
		return base.GetExtendToggle(2);
	}

	// Token: 0x06007AFA RID: 31482 RVA: 0x00202418 File Offset: 0x00200618
	public override void SetActive(bool active)
	{
		base.SetUiActive(active);
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(active);
	}

	// Token: 0x06007AFB RID: 31483 RVA: 0x0020244C File Offset: 0x0020064C
	public void SetToggleVisible(bool visible)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(2);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.RootUIComp.Get().SetUIActive(visible);
	}

	// Token: 0x06007AFC RID: 31484 RVA: 0x00202478 File Offset: 0x00200678
	[NullableContext(1)]
	public void SetTextureByPath(string path)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		UiImageSettingModule imageSettingModule = this.ImageSettingModule;
		if (imageSettingModule == null)
		{
			return;
		}
		imageSettingModule.SetTextureByPathAsync(path, texture, null);
	}

	// Token: 0x06007AFD RID: 31485 RVA: 0x002024A4 File Offset: 0x002006A4
	public void UseChangeColor(bool use)
	{
		UUISprite sprite = base.GetSprite(1);
		FColor? fcolor;
		if (sprite != null)
		{
			fcolor = new FColor?(base.GetSprite(1).changeColor);
			sprite.SetChangeColor(use, fcolor);
		}
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return;
		}
		fcolor = new FColor?(base.GetTexture(0).changeColor);
		texture.SetChangeColor(use, fcolor);
	}

	// Token: 0x06007AFE RID: 31486 RVA: 0x002024FE File Offset: 0x002006FE
	public void SetLockActive(bool active)
	{
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(active);
	}

	// Token: 0x06007AFF RID: 31487 RVA: 0x00202514 File Offset: 0x00200714
	public void FlashHighlight()
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
		}, 0.15f * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
	}

	// Token: 0x04003AF8 RID: 15096
	[Nullable(2)]
	private UiImageSettingModule ImageSettingModule;

	// Token: 0x02007571 RID: 30065
	private class EComBuffSubComponent
	{
		// Token: 0x0402884C RID: 165964
		public const int Texture = 0;

		// Token: 0x0402884D RID: 165965
		public const int BgSprite = 1;

		// Token: 0x0402884E RID: 165966
		public const int Toggle = 2;

		// Token: 0x0402884F RID: 165967
		public const int NiaItem = 3;

		// Token: 0x04028850 RID: 165968
		public const int DailyItem = 4;

		// Token: 0x04028851 RID: 165969
		public const int LockBtn = 5;
	}
}
