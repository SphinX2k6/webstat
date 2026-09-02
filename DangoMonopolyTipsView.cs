using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200130B RID: 4875
[NullableContext(2)]
[Nullable(0)]
public class DangoMonopolyTipsView : UiViewBase
{
	// Token: 0x17000B2B RID: 2859
	// (get) Token: 0x060084A6 RID: 33958 RVA: 0x002300A2 File Offset: 0x0022E2A2
	public new DangoMonopolyTipsViewParams OpenParam
	{
		get
		{
			return this.OpenParam as DangoMonopolyTipsViewParams;
		}
	}

	// Token: 0x060084A7 RID: 33959 RVA: 0x002300AF File Offset: 0x0022E2AF
	[NullableContext(1)]
	public DangoMonopolyTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060084A8 RID: 33960 RVA: 0x002300B8 File Offset: 0x0022E2B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x060084A9 RID: 33961 RVA: 0x002300F1 File Offset: 0x0022E2F1
	private void InitDataParam()
	{
	}

	// Token: 0x060084AA RID: 33962 RVA: 0x002300F4 File Offset: 0x0022E2F4
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyTipsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyTipsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060084AB RID: 33963 RVA: 0x00230137 File Offset: 0x0022E337
	protected override void OnBeforeShow()
	{
		this.ShowData().Forget();
	}

	// Token: 0x060084AC RID: 33964 RVA: 0x00230144 File Offset: 0x0022E344
	public UniTask ShowData()
	{
		DangoMonopolyTipsView.<ShowData>d__8 <ShowData>d__;
		<ShowData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowData>d__.<>4__this = this;
		<ShowData>d__.<>1__state = -1;
		<ShowData>d__.<>t__builder.Start<DangoMonopolyTipsView.<ShowData>d__8>(ref <ShowData>d__);
		return <ShowData>d__.<>t__builder.Task;
	}

	// Token: 0x060084AD RID: 33965 RVA: 0x00230187 File Offset: 0x0022E387
	public void UpdateIcon(string icon)
	{
		if (icon != null)
		{
			base.SetTextureShowUntilLoaded(icon, base.GetTexture(0), null);
		}
	}

	// Token: 0x020076B5 RID: 30389
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E53 RID: 167507
		TextureIcon,
		// Token: 0x04028E54 RID: 167508
		TxtDesc
	}
}
