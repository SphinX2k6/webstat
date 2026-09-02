using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

// Token: 0x02000EA0 RID: 3744
[NullableContext(1)]
[Nullable(0)]
public class InputFilter
{
	// Token: 0x06005C95 RID: 23701 RVA: 0x00174684 File Offset: 0x00172884
	[NullableContext(2)]
	public InputFilter(IEnumerable<EInputAction> actions, IEnumerable<EInputAction> blockActions, IEnumerable<EInputAxis> axes, IEnumerable<EInputAxis> blockAxes)
	{
		this.Actions = new HashSet<EInputAction>(actions ?? Enumerable.Empty<EInputAction>());
		this.BlockActions = new HashSet<EInputAction>(blockActions ?? Enumerable.Empty<EInputAction>());
		this.Axes = new HashSet<EInputAxis>(axes ?? Enumerable.Empty<EInputAxis>());
		this.BlockAxes = new HashSet<EInputAxis>(blockAxes ?? Enumerable.Empty<EInputAxis>());
	}

	// Token: 0x06005C96 RID: 23702 RVA: 0x001746EC File Offset: 0x001728EC
	public bool ListenToAction(EInputAction action)
	{
		HashSet<EInputAction> actions = this.Actions;
		return actions != null && actions.Contains(action);
	}

	// Token: 0x06005C97 RID: 23703 RVA: 0x00174700 File Offset: 0x00172900
	public bool ListenToAxis(EInputAxis axis)
	{
		HashSet<EInputAxis> axes = this.Axes;
		return axes != null && axes.Contains(axis);
	}

	// Token: 0x06005C98 RID: 23704 RVA: 0x00174714 File Offset: 0x00172914
	public bool BlockAction(EInputAction action)
	{
		HashSet<EInputAction> blockActions = this.BlockActions;
		return blockActions != null && blockActions.Contains(action);
	}

	// Token: 0x06005C99 RID: 23705 RVA: 0x00174728 File Offset: 0x00172928
	public bool BlockAxis(EInputAxis axis)
	{
		HashSet<EInputAxis> blockAxes = this.BlockAxes;
		return blockAxes != null && blockAxes.Contains(axis);
	}

	// Token: 0x06005C9A RID: 23706 RVA: 0x0017473C File Offset: 0x0017293C
	public InputFilter Union(InputFilter other)
	{
		InputFilter inputFilter = new InputFilter(this.Actions, this.BlockActions, this.Axes, this.BlockAxes);
		SetUtility.AddToSet<EInputAction>(inputFilter.Actions, other.Actions);
		SetUtility.AddToSet<EInputAction>(inputFilter.BlockActions, other.BlockActions);
		SetUtility.AddToSet<EInputAxis>(inputFilter.Axes, other.Axes);
		SetUtility.AddToSet<EInputAxis>(inputFilter.BlockAxes, other.BlockAxes);
		return inputFilter;
	}

	// Token: 0x04002C30 RID: 11312
	public HashSet<EInputAction> Actions;

	// Token: 0x04002C31 RID: 11313
	public HashSet<EInputAction> BlockActions;

	// Token: 0x04002C32 RID: 11314
	public HashSet<EInputAxis> Axes;

	// Token: 0x04002C33 RID: 11315
	public HashSet<EInputAxis> BlockAxes;
}
