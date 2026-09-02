using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000028 RID: 40
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AudioFilterController : Singleton<AudioFilterController>
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000A9 RID: 169 RVA: 0x00005BAB File Offset: 0x00003DAB
	// (set) Token: 0x060000AA RID: 170 RVA: 0x00005BB4 File Offset: 0x00003DB4
	private IFilterState CurrentFilterState
	{
		get
		{
			return this.CurrentFilterStateInternal;
		}
		set
		{
			if (this.CurrentFilterStateInternal == value)
			{
				return;
			}
			if (this.CurrentFilterStateInternal.State != value.State)
			{
				if (string.IsNullOrEmpty(value.State))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Audio;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[FilterState] [SetCurrent] 传入异常的State";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("State", value.State);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				Singleton<AudioSystem>.Instance.SetState("filter", value.State, false);
			}
			this.CurrentFilterStateInternal = value;
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00005C3C File Offset: 0x00003E3C
	protected override bool OnInit()
	{
		this.CurrentFilterStateInternal = this.NoneFilterState;
		return true;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00005C4C File Offset: 0x00003E4C
	private void UpdateFilterState()
	{
		if (!this.UiFilterStack.Empty && this.UiFilterStack.Top.State != "none")
		{
			this.CurrentFilterState = this.UiFilterStack.Top;
			return;
		}
		if (!this.SceneFilterStack.Empty)
		{
			this.CurrentFilterState = this.SceneFilterStack.Top;
			return;
		}
		this.CurrentFilterState = this.NoneFilterState;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00005CC0 File Offset: 0x00003EC0
	public int PushFilterState(string state, PriorityQueue<AudioFilterState> stack, string context = "", int priority = 0)
	{
		int num = this.Uid + 1;
		this.Uid = num;
		int num2 = num;
		AudioFilterState audioFilterState = this.CreateFilterState(num2, state, new int?(priority));
		stack.Push(audioFilterState);
		this.FilterMap[num2] = audioFilterState;
		this.UpdateFilterState();
		return num2;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00005D0C File Offset: 0x00003F0C
	public void RemoveFilterState(int uid, PriorityQueue<AudioFilterState> stack, string context)
	{
		if (uid <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[FilterState] [Remove] uid不大于零,跳过";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Context", context);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		AudioFilterState audioFilterState = null;
		this.FilterMap.TryGetValue(uid, out audioFilterState);
		if (audioFilterState == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[FilterState] [Remove] 传入异常的uid";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("uid", uid);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		stack.Remove(audioFilterState);
		this.FilterMap.Remove(uid);
		this.UpdateFilterState();
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00005DA1 File Offset: 0x00003FA1
	public int PushUiFilterState(string state, string ui)
	{
		return this.PushFilterState(state, this.UiFilterStack, "[UI] " + ui, 0);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00005DBC File Offset: 0x00003FBC
	public void RemoveUiFilterState(int uid, string ui)
	{
		this.RemoveFilterState(uid, this.UiFilterStack, "[UI] " + ui);
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00005DD6 File Offset: 0x00003FD6
	public int PushSceneFilterState(string state, string context, int priority = 0)
	{
		return this.PushFilterState(state, this.SceneFilterStack, "[Scene]" + context, priority);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00005DF1 File Offset: 0x00003FF1
	public void RemoveSceneFilterState(int uid, string context)
	{
		this.RemoveFilterState(uid, this.SceneFilterStack, "[Scene] " + context);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00005E0C File Offset: 0x0000400C
	public unsafe AudioFilterState CreateFilterState(int uid, string state, int? priority = null)
	{
		if (!string.IsNullOrEmpty(state))
		{
			return new AudioFilterState(uid, state, priority);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "[FilterState] [Create] 传入异常的State";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("State", state);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("priority", priority);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return this.NoneFilterState;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00005E88 File Offset: 0x00004088
	public AudioFilterController()
	{
		Comparison<AudioFilterState> compare;
		if ((compare = AudioFilterController.<>O.<0>__Compare) == null)
		{
			compare = (AudioFilterController.<>O.<0>__Compare = new Comparison<AudioFilterState>(AudioFilterState.Compare));
		}
		this.UiFilterStack = new PriorityQueue<AudioFilterState>(compare);
		Comparison<AudioFilterState> compare2;
		if ((compare2 = AudioFilterController.<>O.<0>__Compare) == null)
		{
			compare2 = (AudioFilterController.<>O.<0>__Compare = new Comparison<AudioFilterState>(AudioFilterState.Compare));
		}
		this.SceneFilterStack = new PriorityQueue<AudioFilterState>(compare2);
		this.NoneFilterState = new AudioFilterState(0, "none", null);
		base..ctor();
	}

	// Token: 0x0400007F RID: 127
	private int Uid;

	// Token: 0x04000080 RID: 128
	private readonly Dictionary<int, AudioFilterState> FilterMap = new Dictionary<int, AudioFilterState>();

	// Token: 0x04000081 RID: 129
	private readonly PriorityQueue<AudioFilterState> UiFilterStack;

	// Token: 0x04000082 RID: 130
	private readonly PriorityQueue<AudioFilterState> SceneFilterStack;

	// Token: 0x04000083 RID: 131
	private readonly AudioFilterState NoneFilterState;

	// Token: 0x04000084 RID: 132
	private IFilterState CurrentFilterStateInternal;

	// Token: 0x0200716E RID: 29038
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027880 RID: 161920
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<AudioFilterState> <0>__Compare;
	}
}
