using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C23 RID: 19491
	public class VillageInfrNewTipsView : UiTickViewBase
	{
		// Token: 0x06032D3B RID: 208187 RVA: 0x00CBC662 File Offset: 0x00CBA862
		[NullableContext(1)]
		public VillageInfrNewTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032D3C RID: 208188 RVA: 0x00CBC66C File Offset: 0x00CBA86C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06032D3D RID: 208189 RVA: 0x00CBC6DC File Offset: 0x00CBA8DC
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrNewTipsView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrNewTipsView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032D3E RID: 208190 RVA: 0x00CBC720 File Offset: 0x00CBA920
		protected override void OnStart()
		{
			int configId = (int)this.OpenParam;
			InfrV2TreeBuild? infrTreeBuild = ConfigBase<VillageInfrConfig>.Instance.GetInfrTreeBuild(configId);
			int num = infrTreeBuild.Value.Requirement().Keys.First<int>();
			if (num == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.ZJC, "新物品提示错误, 没有物品id!", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.CloseMe(null);
				return;
			}
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
			if (itemConfigData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Item;
				ELogAuthor author = ELogAuthor.ZJC;
				string message = "新物品提示错误, 没有物品配置!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
				return;
			}
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = num,
				ItemConfigId = new int?(num)
			};
			this.IconItem.Apply<PropSmallItemGrid>(parameters);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "VillageInfr_Tips_Itemsatisfies", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(itemConfigData.Name, Array.Empty<object>())));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "VillageInfr_Tips_Deliverytips", new <>z__ReadOnlySingleElementList<object>(new TableTextArgNew(infrTreeBuild.Value.Name, Array.Empty<object>())));
		}

		// Token: 0x06032D3F RID: 208191 RVA: 0x00CBC855 File Offset: 0x00CBAA55
		protected override void OnBeforeDestroy()
		{
			ModelBase<ItemModel>.Instance.LastCloseTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x06032D40 RID: 208192 RVA: 0x00CBC86B File Offset: 0x00CBAA6B
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401D96D RID: 121197
		[Nullable(2)]
		private SmallItemGrid IconItem;
	}
}
