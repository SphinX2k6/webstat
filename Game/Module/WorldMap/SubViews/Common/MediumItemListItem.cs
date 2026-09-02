using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BCA RID: 19402
	public class MediumItemListItem : GridProxyAbstract<TItem>
	{
		// Token: 0x06032A42 RID: 207426 RVA: 0x00CAF870 File Offset: 0x00CADA70
		protected override UniTask OnBeforeStartAsync()
		{
			MediumItemListItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MediumItemListItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032A43 RID: 207427 RVA: 0x00CAF8B4 File Offset: 0x00CADAB4
		public override void Refresh(TItem data, bool isSelected, int gridIndex)
		{
			int itemId = data.ItemData.ItemId;
			int count = data.Count;
			this.ItemId = new int?(itemId);
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			string bottomText = this.GetBottomText(count);
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(itemId),
				StarLevel = new int?(itemConfigData.QualityId),
				BottomText = bottomText,
				IsOmitBottomText = new bool?(false)
			};
			MediumItemGrid gridItem = this.GridItem;
			if (gridItem == null)
			{
				return;
			}
			gridItem.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06032A44 RID: 207428 RVA: 0x00CAF94C File Offset: 0x00CADB4C
		[NullableContext(1)]
		public string GetBottomText(int needCount)
		{
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(this.ItemId.Value, 0);
			if (this.GetBottomTextCallback != null)
			{
				return this.GetBottomTextCallback(needCount);
			}
			string value = (needCount <= commonItemCount) ? "Highlight" : "RedA";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<int>(commonItemCount);
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(needCount);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0401D807 RID: 120839
		[Nullable(2)]
		private MediumItemGrid GridItem;

		// Token: 0x0401D808 RID: 120840
		private int? ItemId;

		// Token: 0x0401D809 RID: 120841
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<int, string> GetBottomTextCallback;

		// Token: 0x0200ACB1 RID: 44209
		public class EComponents
		{
			// Token: 0x04035A62 RID: 219746
			public const int Root = 0;
		}
	}
}
