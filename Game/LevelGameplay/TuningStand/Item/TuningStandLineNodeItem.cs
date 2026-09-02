using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Item
{
	// Token: 0x02006A7E RID: 27262
	public class TuningStandLineNodeItem : UiPanelBase
	{
		// Token: 0x060436F8 RID: 276216 RVA: 0x0115FA38 File Offset: 0x0115DC38
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060436F9 RID: 276217 RVA: 0x0115FA92 File Offset: 0x0115DC92
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetItem(0));
		}

		// Token: 0x060436FA RID: 276218 RVA: 0x0115FAA8 File Offset: 0x0115DCA8
		public void OnStartAnim()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("In", false, null, false);
		}

		// Token: 0x060436FB RID: 276219 RVA: 0x0115FAD8 File Offset: 0x0115DCD8
		public UniTask OnLinkComplete()
		{
			TuningStandLineNodeItem.<OnLinkComplete>d__4 <OnLinkComplete>d__;
			<OnLinkComplete>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnLinkComplete>d__.<>4__this = this;
			<OnLinkComplete>d__.<>1__state = -1;
			<OnLinkComplete>d__.<>t__builder.Start<TuningStandLineNodeItem.<OnLinkComplete>d__4>(ref <OnLinkComplete>d__);
			return <OnLinkComplete>d__.<>t__builder.Task;
		}

		// Token: 0x060436FC RID: 276220 RVA: 0x0115FB1C File Offset: 0x0115DD1C
		public UniTask OnBeforeLinkComplete()
		{
			TuningStandLineNodeItem.<OnBeforeLinkComplete>d__5 <OnBeforeLinkComplete>d__;
			<OnBeforeLinkComplete>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeLinkComplete>d__.<>4__this = this;
			<OnBeforeLinkComplete>d__.<>1__state = -1;
			<OnBeforeLinkComplete>d__.<>t__builder.Start<TuningStandLineNodeItem.<OnBeforeLinkComplete>d__5>(ref <OnBeforeLinkComplete>d__);
			return <OnBeforeLinkComplete>d__.<>t__builder.Task;
		}

		// Token: 0x060436FD RID: 276221 RVA: 0x0115FB5F File Offset: 0x0115DD5F
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer = null;
		}

		// Token: 0x060436FE RID: 276222 RVA: 0x0115FB68 File Offset: 0x0115DD68
		[NullableContext(1)]
		public UUIItem GetActiveNode(ETuningStandGridType type)
		{
			ENodeDefine name = (type == ETuningStandGridType.Start1) ? ENodeDefine.Active1 : ENodeDefine.Active2;
			return base.GetItem((int)name);
		}

		// Token: 0x04025A87 RID: 154247
		[Nullable(2)]
		protected LevelSequencePlayer SequencePlayer;
	}
}
