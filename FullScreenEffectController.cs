using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001CA8 RID: 7336
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FullScreenEffectController : UiControllerBase<FullScreenEffectController>
{
	// Token: 0x0600D760 RID: 55136 RVA: 0x00399980 File Offset: 0x00397B80
	public UniTask BeginEffect(string path, int priority)
	{
		FullScreenEffectController.<BeginEffect>d__3 <BeginEffect>d__;
		<BeginEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeginEffect>d__.<>4__this = this;
		<BeginEffect>d__.path = path;
		<BeginEffect>d__.priority = priority;
		<BeginEffect>d__.<>1__state = -1;
		<BeginEffect>d__.<>t__builder.Start<FullScreenEffectController.<BeginEffect>d__3>(ref <BeginEffect>d__);
		return <BeginEffect>d__.<>t__builder.Task;
	}

	// Token: 0x0600D761 RID: 55137 RVA: 0x003999D3 File Offset: 0x00397BD3
	public void EndEffect(string path)
	{
		if (path == this.CurView.Path)
		{
			this.CurView.DeActive();
			return;
		}
		if (this.PathSet.Contains(path))
		{
			this.PathSet.Remove(path);
		}
	}

	// Token: 0x0600D762 RID: 55138 RVA: 0x00399A10 File Offset: 0x00397C10
	public void EndCurView()
	{
		if (this.CurView == null)
		{
			return;
		}
		this.PathSet.Remove(this.CurView.Path);
		this.CurView.SetEffectVisibility(false, true);
		this.CurView.Destroy();
		this.CurView = null;
		FullScreenEffectView preViewTop = this.GetPreViewTop();
		if (preViewTop == null)
		{
			return;
		}
		this.CurView = preViewTop;
		this.CurView.SetEffectVisibility(true, true);
	}

	// Token: 0x0600D763 RID: 55139 RVA: 0x00399A7C File Offset: 0x00397C7C
	protected override bool OnClear()
	{
		this.PathSet.Clear();
		if (this.CurView != null)
		{
			this.CurView.SetEffectVisibility(false, true);
			this.CurView.Destroy();
		}
		while (!this.PreView.Empty)
		{
			this.PreView.Pop().Destroy();
		}
		return true;
	}

	// Token: 0x0600D764 RID: 55140 RVA: 0x00399AD4 File Offset: 0x00397CD4
	[NullableContext(2)]
	private FullScreenEffectView GetPreViewTop()
	{
		while (!this.PreView.Empty)
		{
			FullScreenEffectView fullScreenEffectView = this.PreView.Pop();
			if (this.PathSet.Contains(fullScreenEffectView.Path))
			{
				this.PathSet.Remove(fullScreenEffectView.Path);
				if (fullScreenEffectView.IsEffectPlay())
				{
					return fullScreenEffectView;
				}
			}
			fullScreenEffectView.Destroy();
		}
		return null;
	}

	// Token: 0x0600D765 RID: 55141 RVA: 0x00399B32 File Offset: 0x00397D32
	public FullScreenEffectController()
	{
		Comparison<FullScreenEffectView> compare;
		if ((compare = FullScreenEffectController.<>O.<0>__Compare) == null)
		{
			compare = (FullScreenEffectController.<>O.<0>__Compare = new Comparison<FullScreenEffectView>(FullScreenEffectView.Compare));
		}
		this.PreView = new PriorityQueue<FullScreenEffectView>(compare);
		base..ctor();
	}

	// Token: 0x0400660B RID: 26123
	[Nullable(2)]
	private FullScreenEffectView CurView;

	// Token: 0x0400660C RID: 26124
	private readonly HashSet<string> PathSet = new HashSet<string>();

	// Token: 0x0400660D RID: 26125
	private readonly PriorityQueue<FullScreenEffectView> PreView;

	// Token: 0x02008004 RID: 32772
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402B907 RID: 178439
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<FullScreenEffectView> <0>__Compare;
	}
}
