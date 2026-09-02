using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A43 RID: 10819
[NullableContext(2)]
[Nullable(0)]
public class SkinShowView : UiViewBase
{
	// Token: 0x06015AAA RID: 88746 RVA: 0x00603F5D File Offset: 0x0060215D
	[NullableContext(1)]
	public SkinShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015AAB RID: 88747 RVA: 0x00603F68 File Offset: 0x00602168
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBackBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015AAC RID: 88748 RVA: 0x00604094 File Offset: 0x00602294
	protected override void OnStart()
	{
		int itemId = (int)this.OpenParam;
		this.CurrentData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(itemId);
	}

	// Token: 0x06015AAD RID: 88749 RVA: 0x006040BE File Offset: 0x006022BE
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x06015AAE RID: 88750 RVA: 0x006040C6 File Offset: 0x006022C6
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015AAF RID: 88751 RVA: 0x006040CF File Offset: 0x006022CF
	private void RefreshView()
	{
		if (this.CurrentData == null)
		{
			return;
		}
		this.RefreshRoleSpine(this.CurrentData).Forget();
		this.RefreshFrameTextureColor(this.CurrentData);
		this.RefreshFrameTextureColor2(this.CurrentData);
	}

	// Token: 0x06015AB0 RID: 88752 RVA: 0x00604104 File Offset: 0x00602304
	private UniTask RefreshRoleSpine(RoleSkinData data)
	{
		SkinShowView.<RefreshRoleSpine>d__8 <RefreshRoleSpine>d__;
		<RefreshRoleSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleSpine>d__.<>4__this = this;
		<RefreshRoleSpine>d__.data = data;
		<RefreshRoleSpine>d__.<>1__state = -1;
		<RefreshRoleSpine>d__.<>t__builder.Start<SkinShowView.<RefreshRoleSpine>d__8>(ref <RefreshRoleSpine>d__);
		return <RefreshRoleSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06015AB1 RID: 88753 RVA: 0x00604150 File Offset: 0x00602350
	private void RefreshFrameTextureColor(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(2).SetUIActive(false);
			return;
		}
		base.GetTexture(2).SetUIActive(true);
		FColor color = FColor.FromHex(data.GetObtainFrameColor1());
		base.GetTexture(2).SetColor(color);
	}

	// Token: 0x06015AB2 RID: 88754 RVA: 0x00604194 File Offset: 0x00602394
	private void RefreshFrameTextureColor2(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(3).SetUIActive(false);
			return;
		}
		base.GetTexture(3).SetUIActive(true);
		FColor color = FColor.FromHex(data.GetObtainFrameColor2());
		base.GetTexture(3).SetColor(color);
	}

	// Token: 0x0400A66B RID: 42603
	private RoleSkinData CurrentData;

	// Token: 0x02008DCC RID: 36300
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FB8B RID: 195467
		BackBtn,
		// Token: 0x0402FB8C RID: 195468
		RoleSpine,
		// Token: 0x0402FB8D RID: 195469
		FrameTexture1,
		// Token: 0x0402FB8E RID: 195470
		FrameTexture2,
		// Token: 0x0402FB8F RID: 195471
		CloseButton
	}
}
