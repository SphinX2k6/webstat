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
	// Token: 0x02006A7C RID: 27260
	[NullableContext(1)]
	[Nullable(0)]
	public class TuningStandLineItem : UiPanelBase
	{
		// Token: 0x060436EF RID: 276207 RVA: 0x0115F903 File Offset: 0x0115DB03
		public TuningStandLineItem(string musicPath)
		{
			this.MusicPath = musicPath;
		}

		// Token: 0x1700A26A RID: 41578
		// (get) Token: 0x060436F0 RID: 276208 RVA: 0x0115F912 File Offset: 0x0115DB12
		protected string MusicPath { get; }

		// Token: 0x060436F1 RID: 276209 RVA: 0x0115F91A File Offset: 0x0115DB1A
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x060436F2 RID: 276210 RVA: 0x0115F940 File Offset: 0x0115DB40
		protected override UniTask OnBeforeStartAsync()
		{
			TuningStandLineItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TuningStandLineItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060436F3 RID: 276211 RVA: 0x0115F983 File Offset: 0x0115DB83
		protected override void OnBeforeDestroy()
		{
			this.MusicItem = null;
		}

		// Token: 0x060436F4 RID: 276212 RVA: 0x0115F98C File Offset: 0x0115DB8C
		public void OnStartAnim()
		{
			TuningStandLineNodeItem musicItem = this.MusicItem;
			if (musicItem == null)
			{
				return;
			}
			musicItem.OnStartAnim();
		}

		// Token: 0x060436F5 RID: 276213 RVA: 0x0115F9A0 File Offset: 0x0115DBA0
		public UniTask OnLinkComplete()
		{
			TuningStandLineItem.<OnLinkComplete>d__10 <OnLinkComplete>d__;
			<OnLinkComplete>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnLinkComplete>d__.<>4__this = this;
			<OnLinkComplete>d__.<>1__state = -1;
			<OnLinkComplete>d__.<>t__builder.Start<TuningStandLineItem.<OnLinkComplete>d__10>(ref <OnLinkComplete>d__);
			return <OnLinkComplete>d__.<>t__builder.Task;
		}

		// Token: 0x060436F6 RID: 276214 RVA: 0x0115F9E4 File Offset: 0x0115DBE4
		public UniTask OnBeforeLinkComplete()
		{
			TuningStandLineItem.<OnBeforeLinkComplete>d__11 <OnBeforeLinkComplete>d__;
			<OnBeforeLinkComplete>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeLinkComplete>d__.<>4__this = this;
			<OnBeforeLinkComplete>d__.<>1__state = -1;
			<OnBeforeLinkComplete>d__.<>t__builder.Start<TuningStandLineItem.<OnBeforeLinkComplete>d__11>(ref <OnBeforeLinkComplete>d__);
			return <OnBeforeLinkComplete>d__.<>t__builder.Task;
		}

		// Token: 0x060436F7 RID: 276215 RVA: 0x0115FA27 File Offset: 0x0115DC27
		public UUIItem GetActiveNode(ETuningStandGridType type)
		{
			return this.MusicItem.GetActiveNode(type);
		}

		// Token: 0x04025A81 RID: 154241
		[Nullable(2)]
		protected TuningStandLineNodeItem MusicItem;

		// Token: 0x0200C9CB RID: 51659
		[NullableContext(0)]
		public enum ELineDefine
		{
			// Token: 0x0403E04C RID: 254028
			Panel
		}
	}
}
