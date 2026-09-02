using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002091 RID: 8337
public class CommonKeySettingView : UiViewBase
{
	// Token: 0x0600FE59 RID: 65113 RVA: 0x0045C25B File Offset: 0x0045A45B
	[NullableContext(1)]
	public CommonKeySettingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FE5A RID: 65114 RVA: 0x0045C264 File Offset: 0x0045A464
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600FE5B RID: 65115 RVA: 0x0045C2C0 File Offset: 0x0045A4C0
	protected override UniTask OnBeforeStartAsync()
	{
		CommonKeySettingView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonKeySettingView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FE5C RID: 65116 RVA: 0x0045C304 File Offset: 0x0045A504
	protected override void OnStart()
	{
		ICommonKeySettingViewOpenData commonKeySettingViewOpenData = this.OpenParam as ICommonKeySettingViewOpenData;
		if (string.IsNullOrEmpty((commonKeySettingViewOpenData != null) ? commonKeySettingViewOpenData.BgSourceId : null))
		{
			return;
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(commonKeySettingViewOpenData.BgSourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
	}

	// Token: 0x040079E1 RID: 31201
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x040079E2 RID: 31202
	[Nullable(2)]
	private CommonKeySettingPanel KeySettingPanel;

	// Token: 0x0200841F RID: 33823
	private static class EComponentDefine
	{
		// Token: 0x0402CC6B RID: 183403
		public const int ItemCaption = 0;

		// Token: 0x0402CC6C RID: 183404
		public const int ItemAttachParent = 1;

		// Token: 0x0402CC6D RID: 183405
		public const int BgTexture = 2;
	}
}
