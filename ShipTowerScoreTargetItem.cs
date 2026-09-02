using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D8 RID: 10712
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerScoreTargetItem : GridProxyAbstract<ShipTowerScoreTargetData>
{
	// Token: 0x060155AF RID: 87471 RVA: 0x005EAF80 File Offset: 0x005E9180
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture))
		};
	}

	// Token: 0x060155B0 RID: 87472 RVA: 0x005EB01C File Offset: 0x005E921C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerScoreTargetItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerScoreTargetItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060155B1 RID: 87473 RVA: 0x005EB05F File Offset: 0x005E925F
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x060155B2 RID: 87474 RVA: 0x005EB061 File Offset: 0x005E9261
	protected override void OnStart()
	{
	}

	// Token: 0x060155B3 RID: 87475 RVA: 0x005EB063 File Offset: 0x005E9263
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x060155B4 RID: 87476 RVA: 0x005EB068 File Offset: 0x005E9268
	[NullableContext(1)]
	public override void Refresh(ShipTowerScoreTargetData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.GetText(2).SetText(this.ItemData.Title, true);
		base.GetText(3).SetText(this.ItemData.ScoreTarget.ToString(), true);
		base.GetSprite(0).SetUIActive(!this.ItemData.IsFinish);
		base.GetSprite(1).SetUIActive(this.ItemData.IsFinish);
		this.UpdateGrade();
	}

	// Token: 0x060155B5 RID: 87477 RVA: 0x005EB0E8 File Offset: 0x005E92E8
	private void UpdateGrade()
	{
		ShipTowerScoreTargetData itemData = this.ItemData;
		string text = (itemData != null) ? itemData.ScoreGradeRes : null;
		base.GetItem(4).SetUIActive(text != null);
		if (text != null)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			base.SetTextureByPath(resourcePath, base.GetTexture(5), null, null);
		}
	}

	// Token: 0x0400A47A RID: 42106
	[Nullable(2)]
	private ShipTowerScoreTargetData ItemData;

	// Token: 0x02008D42 RID: 36162
	private static class EChildType
	{
		// Token: 0x0402F810 RID: 194576
		public const int SpriteUnFinish = 0;

		// Token: 0x0402F811 RID: 194577
		public const int SpriteFinish = 1;

		// Token: 0x0402F812 RID: 194578
		public const int TxtTitle = 2;

		// Token: 0x0402F813 RID: 194579
		public const int TxtScore = 3;

		// Token: 0x0402F814 RID: 194580
		public const int ItemGradeRoot = 4;

		// Token: 0x0402F815 RID: 194581
		public const int TextureGrade = 5;
	}
}
