using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020DA RID: 8410
public class CyberpunkLoadingView : LoadingViewBase
{
	// Token: 0x0601011F RID: 65823 RVA: 0x004693CC File Offset: 0x004675CC
	[NullableContext(1)]
	public CyberpunkLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010120 RID: 65824 RVA: 0x004693F0 File Offset: 0x004675F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010121 RID: 65825 RVA: 0x00469459 File Offset: 0x00467659
	protected override void UpdateProgressRate(float rate)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(rate);
	}

	// Token: 0x06010122 RID: 65826 RVA: 0x0046946D File Offset: 0x0046766D
	protected override void UpdateProgressValue(float value)
	{
	}

	// Token: 0x06010123 RID: 65827 RVA: 0x0046946F File Offset: 0x0046766F
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		this.TickIconRotation(delta);
	}

	// Token: 0x06010124 RID: 65828 RVA: 0x00469480 File Offset: 0x00467680
	private void TickIconRotation(float delta)
	{
		this.IconRotationAngle = (this.IconRotationAngle + 90f * delta / 1000f) % 360f;
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		this.IconRotator.Yaw = this.IconRotationAngle;
		UUIItem uuiitem = sprite;
		FRotator frotator = this.IconRotator.ToUeRotator();
		uuiitem.SetUIRelativeRotation(frotator);
	}

	// Token: 0x04007B36 RID: 31542
	private const float ICON_ROTATION_SPEED = 90f;

	// Token: 0x04007B37 RID: 31543
	private float IconRotationAngle;

	// Token: 0x04007B38 RID: 31544
	[Nullable(1)]
	private readonly Rotator IconRotator = Rotator.Create(0f, 0f, 0f);

	// Token: 0x02008456 RID: 33878
	private class ECyberpunkLoadingDefine
	{
		// Token: 0x0402CD6E RID: 183662
		public const int TextureProgress = 0;

		// Token: 0x0402CD6F RID: 183663
		public const int SpriteIcon = 1;
	}
}
