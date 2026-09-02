using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012FE RID: 4862
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoMonopolyRoundBuffShowItem : GridProxyAbstract<IDangoMonopolyRoundBuffData>
{
	// Token: 0x06008433 RID: 33843 RVA: 0x0022EAB8 File Offset: 0x0022CCB8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
	}

	// Token: 0x06008434 RID: 33844 RVA: 0x0022EB28 File Offset: 0x0022CD28
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyRoundBuffShowItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyRoundBuffShowItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008435 RID: 33845 RVA: 0x0022EB6C File Offset: 0x0022CD6C
	public override void Refresh(IDangoMonopolyRoundBuffData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.SetTextureByPath(this.ItemData.DangoIcon, base.GetTexture(1), null, null);
		base.GetText(2).ShowTextNew(this.ItemData.DangoName);
		base.GetText(3).ShowTextNew(this.ItemData.PropertyDesc);
	}

	// Token: 0x04003EC2 RID: 16066
	private IDangoMonopolyRoundBuffData ItemData;

	// Token: 0x020076A6 RID: 30374
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028E0C RID: 167436
		ItemSelf,
		// Token: 0x04028E0D RID: 167437
		TextureIcon,
		// Token: 0x04028E0E RID: 167438
		TxtName,
		// Token: 0x04028E0F RID: 167439
		TxtDesc
	}
}
