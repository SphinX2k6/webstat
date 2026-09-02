using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain
{
	// Token: 0x02006949 RID: 26953
	public class ActivityDirectTrainProView : UiViewBase
	{
		// Token: 0x06042E45 RID: 273989 RVA: 0x0112B87E File Offset: 0x01129A7E
		[NullableContext(1)]
		public ActivityDirectTrainProView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042E46 RID: 273990 RVA: 0x0112B888 File Offset: 0x01129A88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042E47 RID: 273991 RVA: 0x0112B914 File Offset: 0x01129B14
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityDirectTrainProView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityDirectTrainProView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042E48 RID: 273992 RVA: 0x0112B957 File Offset: 0x01129B57
		protected override void OnStart()
		{
			this.RefreshList();
			UUIInturnAnimController animController = this.AnimController;
			if (animController == null)
			{
				return;
			}
			animController.Play("Start", -1, false);
		}

		// Token: 0x06042E49 RID: 273993 RVA: 0x0112B976 File Offset: 0x01129B76
		protected override void OnBeforeShow()
		{
			this.RefreshList();
		}

		// Token: 0x06042E4A RID: 273994 RVA: 0x0112B980 File Offset: 0x01129B80
		private void RefreshList()
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
			IReadOnlyDictionary<int, IDirectTrainSubActivityCache> allProSubActivityCaches = instance.GetAllProSubActivityCaches();
			IReadOnlyList<DirectTrainSubActivityViewModel> source = instance.BuildSubActivityViewModels(instance.GetProSubActivityIds(), allProSubActivityCaches, instance.GetProMainActivityId());
			this.ItemLayout.RefreshByData(source.ToList<DirectTrainSubActivityViewModel>(), null, false);
		}

		// Token: 0x06042E4B RID: 273995 RVA: 0x0112B9CE File Offset: 0x01129BCE
		[NullableContext(1)]
		private DirectTrainSubActivityItem CreateSubActivityItem()
		{
			return new DirectTrainSubActivityItem();
		}

		// Token: 0x06042E4C RID: 273996 RVA: 0x0112B9D8 File Offset: 0x01129BD8
		private void OnClickHelp()
		{
			int proMainActivityHelpId = ModelBase<DirectTrainModel>.Instance.GetProMainActivityHelpId();
			if (proMainActivityHelpId <= 0)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(proMainActivityHelpId);
		}

		// Token: 0x06042E4D RID: 273997 RVA: 0x0112BA00 File Offset: 0x01129C00
		private void OnCloseView()
		{
			base.CloseMe(null);
		}

		// Token: 0x0402544E RID: 152654
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402544F RID: 152655
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DirectTrainSubActivityItem, DirectTrainSubActivityViewModel> ItemLayout;

		// Token: 0x04025450 RID: 152656
		[Nullable(2)]
		private UUIInturnAnimController AnimController;

		// Token: 0x0200C8E6 RID: 51430
		private enum EProComponents
		{
			// Token: 0x0403DCD0 RID: 253136
			ItemCaption,
			// Token: 0x0403DCD1 RID: 253137
			Content,
			// Token: 0x0403DCD2 RID: 253138
			SubItemPrefab
		}
	}
}
