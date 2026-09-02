using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029CE RID: 10702
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerReviewItem : GridProxyAbstract<ShipTowerReviewItemData>
{
	// Token: 0x0601555C RID: 87388 RVA: 0x005E9A8C File Offset: 0x005E7C8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
	}

	// Token: 0x0601555D RID: 87389 RVA: 0x005E9B28 File Offset: 0x005E7D28
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerReviewItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerReviewItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601555E RID: 87390 RVA: 0x005E9B6B File Offset: 0x005E7D6B
	public override void Refresh(ShipTowerReviewItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0601555F RID: 87391 RVA: 0x005E9B74 File Offset: 0x005E7D74
	public void Refresh(ShipTowerReviewItemData data)
	{
		this.ItemData = data;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(this.ItemData.Title, true);
		}
		string textStringId = "GhostShipPointNoColor_Text";
		UUIText text2 = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, textStringId, new <>z__ReadOnlySingleElementList<object>(this.ItemData.Score.ToString()));
		bool flag = this.ItemData.Grade != null;
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(flag);
		}
		if (flag && this.ItemData.Grade != null)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.ItemData.Grade);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(this.ItemData.IsQuickPass);
		}
		bool stageIsEndlessById = ModelBase<ShipTowerModel>.Instance.GetStageIsEndlessById(this.ItemData.StageId);
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(stageIsEndlessById);
		}
		UUIText text3 = base.GetText(3);
		if (text3 != null)
		{
			text3.SetUIActive(!stageIsEndlessById);
		}
		if (!stageIsEndlessById)
		{
			int stageOrderIndexById = ModelBase<ShipTowerModel>.Instance.GetStageOrderIndexById(this.ItemData.StageId);
			UUIText text4 = base.GetText(3);
			if (text4 == null)
			{
				return;
			}
			text4.SetText(stageOrderIndexById.ToString(), true);
		}
	}

	// Token: 0x0400A460 RID: 42080
	private ShipTowerReviewItemData ItemData;

	// Token: 0x0400A461 RID: 42081
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerReviewItemData> ClickCallBack;

	// Token: 0x02008D32 RID: 36146
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7CA RID: 194506
		public const int TxtName = 0;

		// Token: 0x0402F7CB RID: 194507
		public const int TxtScore = 1;

		// Token: 0x0402F7CC RID: 194508
		public const int TextureGrade = 2;

		// Token: 0x0402F7CD RID: 194509
		public const int LevelNumText = 3;

		// Token: 0x0402F7CE RID: 194510
		public const int QuickPassItem = 4;

		// Token: 0x0402F7CF RID: 194511
		public const int SpriteEndless = 5;
	}
}
