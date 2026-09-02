using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022BD RID: 8893
public class MotorcycleTabItem : CommonTabItem, ITabViewRegister
{
	// Token: 0x06010D01 RID: 68865 RVA: 0x00499E8E File Offset: 0x0049808E
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUISprite)));
	}

	// Token: 0x06010D02 RID: 68866 RVA: 0x00499EB4 File Offset: 0x004980B4
	protected override void OnStart()
	{
		base.OnStart();
		string stringConfig = ConfigCommonParamById.GetStringConfig("MotorPreviewRedDotIcon");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			this.SetSpriteByPath(stringConfig, base.GetSprite(4), true, null, null);
		}
	}

	// Token: 0x06010D03 RID: 68867 RVA: 0x00499EF3 File Offset: 0x004980F3
	[NullableContext(1)]
	public void RegisterViewModule(UiTabViewBase tabView)
	{
		tabView.AddUiTabViewBehavior<UiTabCamera>().SetTabData((EUiTabViewName)tabView.GetViewName());
		tabView.AddUiTabViewBehavior<UiTabSequence>().SetRootItem(tabView);
		Action<UiTabViewBase> onRegisterViewCallback = this.OnRegisterViewCallback;
		if (onRegisterViewCallback == null)
		{
			return;
		}
		onRegisterViewCallback(tabView);
	}

	// Token: 0x06010D04 RID: 68868 RVA: 0x00499F28 File Offset: 0x00498128
	public void BindPreviewRedDot(ERedDotName redDotName)
	{
		this.UnBindPreviewRedDot();
		UUISprite sprite = base.GetSprite(4);
		this.PreviewRedDotName = new ERedDotName?(redDotName);
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, sprite, null, 0);
	}

	// Token: 0x06010D05 RID: 68869 RVA: 0x00499F5D File Offset: 0x0049815D
	public void UnBindPreviewRedDot()
	{
		if (this.PreviewRedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.PreviewRedDotName.Value, base.GetSprite(4), 0);
			this.PreviewRedDotName = null;
		}
	}

	// Token: 0x06010D06 RID: 68870 RVA: 0x00499F95 File Offset: 0x00498195
	public void SetSubRedDotVisible(bool isVisible)
	{
		base.GetSprite(4).SetUIActive(isVisible);
	}

	// Token: 0x04008490 RID: 33936
	private ERedDotName? PreviewRedDotName;

	// Token: 0x04008491 RID: 33937
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UiTabViewBase> OnRegisterViewCallback;

	// Token: 0x0200857B RID: 34171
	protected class ECommonTabItem
	{
		// Token: 0x0402D2A8 RID: 185000
		public const int Icon = 0;

		// Token: 0x0402D2A9 RID: 185001
		public const int Toggle = 1;

		// Token: 0x0402D2AA RID: 185002
		public const int RedDot = 2;

		// Token: 0x0402D2AB RID: 185003
		public const int Transition = 3;

		// Token: 0x0402D2AC RID: 185004
		public const int SubRedDot = 4;
	}
}
