using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A38 RID: 10808
[NullableContext(2)]
[Nullable(0)]
public class RoleSkinShareView : UiPanelBase
{
	// Token: 0x06015A0D RID: 88589 RVA: 0x00600458 File Offset: 0x005FE658
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015A0E RID: 88590 RVA: 0x006004E2 File Offset: 0x005FE6E2
	protected override void OnStart()
	{
		this.CurrentData = (this.OpenParam as RoleSkinData);
		this.RefreshView();
	}

	// Token: 0x06015A0F RID: 88591 RVA: 0x006004FB File Offset: 0x005FE6FB
	private void RefreshView()
	{
		this.RefreshRoleTexture(this.CurrentData);
		this.RefreshTitleText(this.CurrentData);
		this.RefreshSubTitleText(this.CurrentData);
	}

	// Token: 0x06015A10 RID: 88592 RVA: 0x00600524 File Offset: 0x005FE724
	private void RefreshRoleTexture(RoleSkinData data)
	{
		if (data == null)
		{
			return;
		}
		string shareTexturePath = data.GetShareTexturePath();
		base.SetTextureByPath(shareTexturePath, base.GetTexture(0), null, null);
	}

	// Token: 0x06015A11 RID: 88593 RVA: 0x00600554 File Offset: 0x005FE754
	private void RefreshTitleText(RoleSkinData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.GetTitleName(), Array.Empty<object>());
	}

	// Token: 0x06015A12 RID: 88594 RVA: 0x00600572 File Offset: 0x005FE772
	private void RefreshSubTitleText(RoleSkinData data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.GetSubTitle(), Array.Empty<object>());
	}

	// Token: 0x0400A647 RID: 42567
	private RoleSkinData CurrentData;

	// Token: 0x02008DBD RID: 36285
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FB20 RID: 195360
		RoleTexture,
		// Token: 0x0402FB21 RID: 195361
		TitleText,
		// Token: 0x0402FB22 RID: 195362
		SubTitleText
	}
}
