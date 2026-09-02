using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024E7 RID: 9447
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionAssembleSuitItem : GridProxyAbstract<VisionAssembleSuitItemData>
{
	// Token: 0x06012574 RID: 75124 RVA: 0x0050AA96 File Offset: 0x00508C96
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06012575 RID: 75125 RVA: 0x0050AAD0 File Offset: 0x00508CD0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionAssembleSuitItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionAssembleSuitItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012576 RID: 75126 RVA: 0x0050AB14 File Offset: 0x00508D14
	[NullableContext(1)]
	public override void Refresh(VisionAssembleSuitItemData data, bool isSelected, int gridIndex)
	{
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data.FetterGroupId);
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem != null)
		{
			visionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
		}
		UUIText text = base.GetText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendLiteral("（");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.CurrentProgress);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.MaxProgress);
		defaultInterpolatedStringHandler.AppendLiteral("）");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x04008F07 RID: 36615
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x020087F8 RID: 34808
	private enum EComponent
	{
		// Token: 0x0402DEFD RID: 188157
		ElementItem,
		// Token: 0x0402DEFE RID: 188158
		InfoText
	}
}
