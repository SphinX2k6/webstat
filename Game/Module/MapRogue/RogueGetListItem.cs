using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200594B RID: 22859
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueGetListItem : SliderItem
	{
		// Token: 0x06039F6D RID: 237421 RVA: 0x00EAB9C2 File Offset: 0x00EA9BC2
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06039F6E RID: 237422 RVA: 0x00EAB9FB File Offset: 0x00EA9BFB
		protected override void OnStart()
		{
			this.LevelSequencePlayerInstance = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayerInstance.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
		}

		// Token: 0x06039F6F RID: 237423 RVA: 0x00EABA26 File Offset: 0x00EA9C26
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayerInstance != null)
			{
				this.LevelSequencePlayerInstance.Clear();
				this.LevelSequencePlayerInstance = null;
			}
		}

		// Token: 0x06039F70 RID: 237424 RVA: 0x00EABA42 File Offset: 0x00EA9C42
		private void FinishSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				base.FinishPlayStart();
				return;
			}
			if (sequenceName == "Close")
			{
				base.FinishPlayEnd();
			}
		}

		// Token: 0x06039F71 RID: 237425 RVA: 0x00EABA6C File Offset: 0x00EA9C6C
		protected override void PlayStart()
		{
			this.LevelSequencePlayerInstance.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06039F72 RID: 237426 RVA: 0x00EABA94 File Offset: 0x00EA9C94
		public override void PlayEnd()
		{
			this.LevelSequencePlayerInstance.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x06039F73 RID: 237427 RVA: 0x00EABABC File Offset: 0x00EA9CBC
		protected override void OnActiveStatusChange(bool value)
		{
		}

		// Token: 0x06039F74 RID: 237428 RVA: 0x00EABAC0 File Offset: 0x00EA9CC0
		public override UniTask AsyncLoadUiResource()
		{
			RogueGetListItem.<AsyncLoadUiResource>d__9 <AsyncLoadUiResource>d__;
			<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AsyncLoadUiResource>d__.<>4__this = this;
			<AsyncLoadUiResource>d__.<>1__state = -1;
			<AsyncLoadUiResource>d__.<>t__builder.Start<RogueGetListItem.<AsyncLoadUiResource>d__9>(ref <AsyncLoadUiResource>d__);
			return <AsyncLoadUiResource>d__.<>t__builder.Task;
		}

		// Token: 0x06039F75 RID: 237429 RVA: 0x00EABB04 File Offset: 0x00EA9D04
		public UniTask Refresh(IRogueGetListItemData data)
		{
			RogueGetListItem.<Refresh>d__10 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.data = data;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RogueGetListItem.<Refresh>d__10>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x04020D93 RID: 134547
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x04020D94 RID: 134548
		[Nullable(2)]
		protected IRogueGetListItemData Data;
	}
}
