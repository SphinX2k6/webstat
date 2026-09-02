using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Components
{
	// Token: 0x020058AB RID: 22699
	public class MarkSelectComponent : MarkPanelBase
	{
		// Token: 0x06039AC0 RID: 236224 RVA: 0x00E9F934 File Offset: 0x00E9DB34
		[NullableContext(1)]
		protected virtual string GetSelectSequenceName()
		{
			return "xuanzhong";
		}

		// Token: 0x06039AC1 RID: 236225 RVA: 0x00E9F93B File Offset: 0x00E9DB3B
		[NullableContext(1)]
		protected virtual string GetUnSelectSequenceName()
		{
			return "Close";
		}

		// Token: 0x06039AC2 RID: 236226 RVA: 0x00E9F942 File Offset: 0x00E9DB42
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06039AC3 RID: 236227 RVA: 0x00E9F955 File Offset: 0x00E9DB55
		public override void SetActive(bool visibility)
		{
			this.PlaySequenceAndSetActive(visibility);
		}

		// Token: 0x06039AC4 RID: 236228 RVA: 0x00E9F960 File Offset: 0x00E9DB60
		protected UniTask<bool> PlaySequenceAndSetActive(bool visibility)
		{
			MarkSelectComponent.<PlaySequenceAndSetActive>d__6 <PlaySequenceAndSetActive>d__;
			<PlaySequenceAndSetActive>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlaySequenceAndSetActive>d__.<>4__this = this;
			<PlaySequenceAndSetActive>d__.visibility = visibility;
			<PlaySequenceAndSetActive>d__.<>1__state = -1;
			<PlaySequenceAndSetActive>d__.<>t__builder.Start<MarkSelectComponent.<PlaySequenceAndSetActive>d__6>(ref <PlaySequenceAndSetActive>d__);
			return <PlaySequenceAndSetActive>d__.<>t__builder.Task;
		}

		// Token: 0x04020AFA RID: 133882
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020AFB RID: 133883
		protected bool LastVisibility;
	}
}
