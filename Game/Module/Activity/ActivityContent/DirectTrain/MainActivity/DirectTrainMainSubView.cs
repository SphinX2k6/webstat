using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x02006954 RID: 26964
	public class DirectTrainMainSubView : ActivitySubViewBase
	{
		// Token: 0x06042E99 RID: 274073 RVA: 0x0112CE90 File Offset: 0x0112B090
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042E9A RID: 274074 RVA: 0x0112CEFC File Offset: 0x0112B0FC
		protected override UniTask OnBeforeStartAsync()
		{
			DirectTrainMainSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DirectTrainMainSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042E9B RID: 274075 RVA: 0x0112CF3F File Offset: 0x0112B13F
		protected override void OnStart()
		{
		}

		// Token: 0x06042E9C RID: 274076 RVA: 0x0112CF44 File Offset: 0x0112B144
		protected override UniTask OnBeforeShowSelfAsync()
		{
			DirectTrainMainSubView.<OnBeforeShowSelfAsync>d__7 <OnBeforeShowSelfAsync>d__;
			<OnBeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowSelfAsync>d__.<>4__this = this;
			<OnBeforeShowSelfAsync>d__.<>1__state = -1;
			<OnBeforeShowSelfAsync>d__.<>t__builder.Start<DirectTrainMainSubView.<OnBeforeShowSelfAsync>d__7>(ref <OnBeforeShowSelfAsync>d__);
			return <OnBeforeShowSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042E9D RID: 274077 RVA: 0x0112CF88 File Offset: 0x0112B188
		protected override void OnRefreshView()
		{
			if (this.ItemLayout == null)
			{
				return;
			}
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			if (instance == null)
			{
				return;
			}
			DirectTrainModel directTrainModel = instance;
			IReadOnlyList<int> mainSubActivityIds = instance.GetMainSubActivityIds();
			IReadOnlyDictionary<int, IDirectTrainSubActivityCache> allSubActivityCaches = instance.GetAllSubActivityCaches();
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			IReadOnlyList<DirectTrainSubActivityViewModel> source = directTrainModel.BuildSubActivityViewModels(mainSubActivityIds, allSubActivityCaches, (activityBaseData != null) ? activityBaseData.Id : 0);
			this.ItemLayout.RefreshByData(source.ToList<DirectTrainSubActivityViewModel>(), delegate
			{
				if (this.PendingPlayStartAnim)
				{
					this.PendingPlayStartAnim = false;
					UUIInturnAnimController animController = this.AnimController;
					if (animController == null)
					{
						return;
					}
					animController.Play("Start", -1, false);
				}
			}, false);
		}

		// Token: 0x06042E9E RID: 274078 RVA: 0x0112CFEB File Offset: 0x0112B1EB
		[NullableContext(1)]
		private DirectTrainSubActivityItem CreateSubActivityItem()
		{
			return new DirectTrainSubActivityItem();
		}

		// Token: 0x04025469 RID: 152681
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DirectTrainSubActivityItem, DirectTrainSubActivityViewModel> ItemLayout;

		// Token: 0x0402546A RID: 152682
		[Nullable(2)]
		private UUIInturnAnimController AnimController;

		// Token: 0x0402546B RID: 152683
		private bool PendingPlayStartAnim;

		// Token: 0x0200C8F3 RID: 51443
		private enum EPlotArriveGuideComponents
		{
			// Token: 0x0403DD0D RID: 253197
			Content,
			// Token: 0x0403DD0E RID: 253198
			SubItemPrefab
		}
	}
}
