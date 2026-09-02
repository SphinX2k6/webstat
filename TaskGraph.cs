using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034D3 RID: 13523
[NullableContext(1)]
[Nullable(0)]
public class TaskGraph : IStaticVariableResetter
{
	// Token: 0x0601C917 RID: 117015 RVA: 0x0088FEE8 File Offset: 0x0088E0E8
	static TaskGraph()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TaskGraph.CreateStaticDefaultValue), new Action(TaskGraph.ResetStaticDefaultValue));
	}

	// Token: 0x0601C918 RID: 117016 RVA: 0x0088FF08 File Offset: 0x0088E108
	private int Compare(string a, string b)
	{
		Dictionary<string, int> nodeCumulativePriorities = TaskUtils.GetNodeCumulativePriorities(this.GraphDependencyMap, this.NodesWithNoDependencies);
		return nodeCumulativePriorities[a] - nodeCumulativePriorities[b];
	}

	// Token: 0x0601C919 RID: 117017 RVA: 0x0088FF38 File Offset: 0x0088E138
	public TaskGraph(Dictionary<string, IGraphNode> nodeMap, [Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})] List<ValueTuple<string, string>> dependencies)
	{
		foreach (KeyValuePair<string, IGraphNode> keyValuePair in nodeMap)
		{
			this.GraphDependencyMap[keyValuePair.Key] = new GraphNodeWithDependenciesImpl
			{
				Run = keyValuePair.Value.Run,
				Priority = keyValuePair.Value.Priority,
				DependsOn = new HashSet<string>(),
				DependedOnBy = new HashSet<string>(),
				Failed = false
			};
		}
		foreach (ValueTuple<string, string> valueTuple in dependencies)
		{
			string item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			IGraphNodeWithDependencies valueOrDefault = this.GraphDependencyMap.GetValueOrDefault(item);
			IGraphNodeWithDependencies valueOrDefault2 = this.GraphDependencyMap.GetValueOrDefault(item2);
			if (valueOrDefault == null)
			{
				throw new Exception("检查dependencies参数传入的被依赖ID: " + item + ", 不在nodeMap中");
			}
			if (valueOrDefault2 == null)
			{
				throw new Exception("检查dependencies参数传入的依赖ID " + item2 + ", 不在nodeMap中");
			}
			valueOrDefault.DependedOnBy.Add(item2);
			valueOrDefault2.DependsOn.Add(item);
		}
		this.NodesWithNoDependencies.AddRange(TaskUtils.GetNodesWithNoDependencies(this.GraphDependencyMap));
		if (this.NodesWithNoDependencies.Count == 0 && nodeMap.Count > 0)
		{
			throw new Exception("找不到Task执行起点, 可能有一个依赖链包含了所有的Task");
		}
		OneOf<IGraphNodeWithCyclicDependency, IGraphNodeWithNoCyclicDependency> oneOf = TaskUtils.GraphHasCycles(this.GraphDependencyMap);
		if (oneOf.IsT1 && oneOf.AsT1.HasCycle)
		{
			throw new Exception("检测到了循环依赖:\n" + string.Join("\n", oneOf.AsT1.Cycle));
		}
		if (oneOf.IsT2 && oneOf.AsT2.HasCycle)
		{
			throw new Exception("检测到了循环依赖:");
		}
		bool visualizeTaskGraph = TaskGraph.VisualizeTaskGraph;
	}

	// Token: 0x0601C91A RID: 117018 RVA: 0x00890154 File Offset: 0x0088E354
	[NullableContext(2)]
	public UniTask Run(IRunOptions options = null)
	{
		TaskGraph.<Run>d__6 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.options = options;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<TaskGraph.<Run>d__6>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601C91B RID: 117019 RVA: 0x0089019F File Offset: 0x0088E39F
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0601C91C RID: 117020 RVA: 0x008901A1 File Offset: 0x0088E3A1
	public static void ResetStaticDefaultValue()
	{
		TaskGraph.VisualizeTaskGraph = false;
	}

	// Token: 0x0400E61D RID: 58909
	private readonly Dictionary<string, IGraphNodeWithDependencies> GraphDependencyMap = new Dictionary<string, IGraphNodeWithDependencies>();

	// Token: 0x0400E61E RID: 58910
	private readonly List<string> NodesWithNoDependencies = new List<string>();

	// Token: 0x0400E61F RID: 58911
	public static bool VisualizeTaskGraph;
}
