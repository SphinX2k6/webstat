using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002515 RID: 9493
[NullableContext(2)]
[Nullable(0)]
public class VisionMainFetterSuitItem : GridProxyAbstract<PhantomFetterGroup>
{
	// Token: 0x060126BC RID: 75452 RVA: 0x00510E41 File Offset: 0x0050F041
	public VisionMainFetterSuitItem(UUIItem uiItem = null)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x060126BD RID: 75453 RVA: 0x00510E50 File Offset: 0x0050F050
	public UniTask Init()
	{
		VisionMainFetterSuitItem.<Init>d__2 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionMainFetterSuitItem.<Init>d__2>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060126BE RID: 75454 RVA: 0x00510E93 File Offset: 0x0050F093
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x060126BF RID: 75455 RVA: 0x00510ECC File Offset: 0x0050F0CC
	public void Update(PhantomFetterGroup? fetterGroupData)
	{
		string hexStr;
		string path;
		if (fetterGroupData == null)
		{
			hexStr = ConfigBase<PhantomBattleConfig>.Instance.GetVisionFetterDefaultColor();
			path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionFetterDefaultTexture();
		}
		else
		{
			hexStr = fetterGroupData.Value.FetterElementColor;
			path = fetterGroupData.Value.FetterElementPath;
		}
		FColor color = FColor.FromHex(hexStr);
		base.GetSprite(0).SetColor(color);
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetWidth(100f);
		}
		if (texture != null)
		{
			texture.SetHeight(100f);
		}
		if (texture == null)
		{
			return;
		}
		texture.SetAnchorOffset(new FVector2D(0f, 0f));
	}

	// Token: 0x060126C0 RID: 75456 RVA: 0x00510F89 File Offset: 0x0050F189
	public override void Refresh(PhantomFetterGroup data, bool isSelected, int gridIndex)
	{
		this.Update(new PhantomFetterGroup?(data));
	}

	// Token: 0x04008FC0 RID: 36800
	private readonly UUIItem SourceItem;
}
