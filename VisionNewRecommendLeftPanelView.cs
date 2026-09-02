using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002539 RID: 9529
[NullableContext(1)]
[Nullable(0)]
public class VisionNewRecommendLeftPanelView : UiPanelBase
{
	// Token: 0x0601289F RID: 75935 RVA: 0x0051B854 File Offset: 0x00519A54
	public VisionNewRecommendLeftPanelView(VisionNewRecommendProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x060128A0 RID: 75936 RVA: 0x0051B864 File Offset: 0x00519A64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x060128A1 RID: 75937 RVA: 0x0051B92C File Offset: 0x00519B2C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionNewRecommendLeftPanelView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionNewRecommendLeftPanelView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060128A2 RID: 75938 RVA: 0x0051B96F File Offset: 0x00519B6F
	protected override void OnStart()
	{
		this.RefreshRoleInfo();
		this.SelectDefaultFetterItem();
	}

	// Token: 0x060128A3 RID: 75939 RVA: 0x0051B980 File Offset: 0x00519B80
	private UniTask InitAllLayouts()
	{
		VisionNewRecommendLeftPanelView.<InitAllLayouts>d__8 <InitAllLayouts>d__;
		<InitAllLayouts>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAllLayouts>d__.<>4__this = this;
		<InitAllLayouts>d__.<>1__state = -1;
		<InitAllLayouts>d__.<>t__builder.Start<VisionNewRecommendLeftPanelView.<InitAllLayouts>d__8>(ref <InitAllLayouts>d__);
		return <InitAllLayouts>d__.<>t__builder.Task;
	}

	// Token: 0x060128A4 RID: 75940 RVA: 0x0051B9C3 File Offset: 0x00519BC3
	private VisionNewRecommendFetterItem InitSystemRecommendItem()
	{
		return new VisionNewRecommendFetterItem
		{
			OnSelectedCallback = new Action<int>(this.OnSystemRecommendItemSelected)
		};
	}

	// Token: 0x060128A5 RID: 75941 RVA: 0x0051B9DC File Offset: 0x00519BDC
	private VisionNewRecommendFetterItem InitUsageRecommendItem()
	{
		return new VisionNewRecommendFetterItem
		{
			OnSelectedCallback = new Action<int>(this.OnUsageRecommendItemSelected)
		};
	}

	// Token: 0x060128A6 RID: 75942 RVA: 0x0051B9F8 File Offset: 0x00519BF8
	private void OnSystemRecommendItemSelected(int index)
	{
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
		int? num = (systemRecommendLayout != null) ? new int?(systemRecommendLayout.GetSelectedGridIndex()) : null;
		if (index == num.GetValueOrDefault() & num != null)
		{
			return;
		}
		List<VisionFetterRecommendInfo> systemRecommendInfoList = this.Proxy.GetSystemRecommendInfoList();
		VisionFetterRecommendInfo visionFetterRecommendInfo = (systemRecommendInfoList != null && index >= 0 && index < systemRecommendInfoList.Count) ? systemRecommendInfoList[index] : null;
		if (visionFetterRecommendInfo == null)
		{
			return;
		}
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
		if (usageRecommendLayout != null)
		{
			usageRecommendLayout.DeselectCurrentGridProxy();
		}
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout2 = this.SystemRecommendLayout;
		if (systemRecommendLayout2 != null)
		{
			systemRecommendLayout2.SelectGridProxy(index, false);
		}
		this.Proxy.CurrentSelectFetterRecommendInfo = visionFetterRecommendInfo;
		Action<Action> refreshSelectedRecommendDetail = this.Proxy.RefreshSelectedRecommendDetail;
		if (refreshSelectedRecommendDetail != null)
		{
			refreshSelectedRecommendDetail(null);
		}
		UiBehaviorLevelSequence mainViewSequence = this.Proxy.MainViewSequence;
		if (mainViewSequence == null)
		{
			return;
		}
		mainViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x060128A7 RID: 75943 RVA: 0x0051BAD4 File Offset: 0x00519CD4
	private void OnUsageRecommendItemSelected(int index)
	{
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
		int? num = (usageRecommendLayout != null) ? new int?(usageRecommendLayout.GetSelectedGridIndex()) : null;
		if (index == num.GetValueOrDefault() & num != null)
		{
			return;
		}
		List<VisionFetterRecommendInfo> usageRecommendInfoList = this.Proxy.GetUsageRecommendInfoList();
		VisionFetterRecommendInfo visionFetterRecommendInfo = (usageRecommendInfoList != null && index >= 0 && index < usageRecommendInfoList.Count) ? usageRecommendInfoList[index] : null;
		if (visionFetterRecommendInfo == null)
		{
			return;
		}
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
		if (systemRecommendLayout != null)
		{
			systemRecommendLayout.DeselectCurrentGridProxy();
		}
		GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout2 = this.UsageRecommendLayout;
		if (usageRecommendLayout2 != null)
		{
			usageRecommendLayout2.SelectGridProxy(index, false);
		}
		this.Proxy.CurrentSelectFetterRecommendInfo = visionFetterRecommendInfo;
		Action<Action> refreshSelectedRecommendDetail = this.Proxy.RefreshSelectedRecommendDetail;
		if (refreshSelectedRecommendDetail != null)
		{
			refreshSelectedRecommendDetail(null);
		}
		UiBehaviorLevelSequence mainViewSequence = this.Proxy.MainViewSequence;
		if (mainViewSequence == null)
		{
			return;
		}
		mainViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
	}

	// Token: 0x060128A8 RID: 75944 RVA: 0x0051BBB0 File Offset: 0x00519DB0
	public void SelectDefaultFetterItem()
	{
		if (this.Proxy.IsFromRoleDev)
		{
			this.Proxy.IsFromRoleDevFirstSelect = true;
			int num = this.Proxy.GetSelectedPlanIdCallBack(this.Proxy.CurrentSelectRoleId);
			GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout = this.SystemRecommendLayout;
			if (((systemRecommendLayout != null) ? systemRecommendLayout.GetLayoutItemByKey(num) : null) == null)
			{
				GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout = this.UsageRecommendLayout;
				if (((usageRecommendLayout != null) ? usageRecommendLayout.GetLayoutItemByKey(num) : null) != null)
				{
					GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout2 = this.UsageRecommendLayout;
					if (usageRecommendLayout2 == null)
					{
						return;
					}
					usageRecommendLayout2.SelectGridProxyByKey(num, true);
				}
				return;
			}
			GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout2 = this.SystemRecommendLayout;
			if (systemRecommendLayout2 == null)
			{
				return;
			}
			systemRecommendLayout2.SelectGridProxyByKey(num, true);
			return;
		}
		else
		{
			List<VisionFetterRecommendInfo> usageRecommendInfoList = this.Proxy.GetUsageRecommendInfoList();
			if (usageRecommendInfoList != null && usageRecommendInfoList.Count > 0)
			{
				GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> usageRecommendLayout3 = this.UsageRecommendLayout;
				if (usageRecommendLayout3 == null)
				{
					return;
				}
				usageRecommendLayout3.SelectGridProxy(0, true);
				return;
			}
			else
			{
				GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> systemRecommendLayout3 = this.SystemRecommendLayout;
				if (systemRecommendLayout3 == null)
				{
					return;
				}
				systemRecommendLayout3.SelectGridProxy(0, true);
				return;
			}
		}
	}

	// Token: 0x060128A9 RID: 75945 RVA: 0x0051BC96 File Offset: 0x00519E96
	public void RefreshRoleInfo()
	{
		this.RefreshRoleIcon();
		this.RefreshRoleName();
	}

	// Token: 0x060128AA RID: 75946 RVA: 0x0051BCA4 File Offset: 0x00519EA4
	private RoleSkin? GetRoleSkinConfig()
	{
		RoleSkinModel instance = ModelBase<RoleSkinModel>.Instance;
		RoleSkinData roleSkinData = (instance != null) ? instance.GetRoleSkinDataByRoleId(this.Proxy.CurrentSelectRoleId) : null;
		if (roleSkinData != null)
		{
			return new RoleSkin?(roleSkinData.GetRoleSkinConfig());
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.Proxy.CurrentSelectRoleId);
		if (roleConfig == null)
		{
			return null;
		}
		return ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleConfig.Value.SkinId);
	}

	// Token: 0x060128AB RID: 75947 RVA: 0x0051BD20 File Offset: 0x00519F20
	private void RefreshRoleIcon()
	{
		RoleSkin? roleSkinConfig = this.GetRoleSkinConfig();
		if (roleSkinConfig == null)
		{
			return;
		}
		string tag = "RoleIcon1";
		string roleSkinConfigParam = ConfigBase<ComponentConfig>.Instance.GetRoleSkinConfigParam(tag);
		if (roleSkinConfigParam != null && roleSkinConfigParam != "")
		{
			PropertyInfo property = roleSkinConfig.Value.GetType().GetProperty(roleSkinConfigParam);
			if (property != null)
			{
				string text = property.GetValue(roleSkinConfig.Value) as string;
				if (text != null)
				{
					base.SetTextureByPath(text, base.GetTexture(0), null, null);
				}
			}
		}
	}

	// Token: 0x060128AC RID: 75948 RVA: 0x0051BDB8 File Offset: 0x00519FB8
	private void RefreshRoleName()
	{
		RoleSkin? roleSkinConfig = this.GetRoleSkinConfig();
		if (roleSkinConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(ConfigBase<RoleConfig>.Instance.GetRoleName(roleSkinConfig.Value.Name), true);
	}

	// Token: 0x04009076 RID: 36982
	private readonly VisionNewRecommendProxy Proxy;

	// Token: 0x04009077 RID: 36983
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> SystemRecommendLayout;

	// Token: 0x04009078 RID: 36984
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionNewRecommendFetterItem, VisionFetterRecommendInfo> UsageRecommendLayout;

	// Token: 0x0200885E RID: 34910
	[NullableContext(0)]
	private enum EComp
	{
		// Token: 0x0402E0FA RID: 188666
		RoleIcon,
		// Token: 0x0402E0FB RID: 188667
		RoleName,
		// Token: 0x0402E0FC RID: 188668
		UsageRecommendLayout,
		// Token: 0x0402E0FD RID: 188669
		UsageRecommendItem,
		// Token: 0x0402E0FE RID: 188670
		SystemRecommendLayout,
		// Token: 0x0402E0FF RID: 188671
		SystemRecommendItem,
		// Token: 0x0402E100 RID: 188672
		PnlUsageRecommend,
		// Token: 0x0402E101 RID: 188673
		PnlSystemRecommend
	}
}
