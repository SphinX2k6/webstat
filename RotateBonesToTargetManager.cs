using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C0 RID: 12480
[NullableContext(1)]
[Nullable(0)]
public class RotateBonesToTargetManager : IClear
{
	// Token: 0x170022A1 RID: 8865
	// (get) Token: 0x06019B7C RID: 105340 RVA: 0x0077BED4 File Offset: 0x0077A0D4
	// (set) Token: 0x06019B7D RID: 105341 RVA: 0x0077BEDC File Offset: 0x0077A0DC
	public CharacterActorComponent ActorComp { get; private set; }

	// Token: 0x06019B7E RID: 105342 RVA: 0x0077BEE8 File Offset: 0x0077A0E8
	public RotateBonesToTargetManager(CharacterActorComponent actorComp)
	{
		this.ActorComp = actorComp;
		this.SkillComp = this.ActorComp.Entity.GetComponent<CharacterSkillComponent>();
		this.AiComp = this.ActorComp.Entity.GetComponent<CharacterAiComponent>();
	}

	// Token: 0x06019B7F RID: 105343 RVA: 0x0077BF93 File Offset: 0x0077A193
	public bool ClearObject()
	{
		this.Params.RemoveAllNodeWithoutHead();
		this.PauseParams.RemoveAllNodeWithoutHead();
		this.CurrentAlphaMap.Clear();
		this.PauseAlphaMap.Clear();
		this.DefaultTargetOffset.Reset();
		return true;
	}

	// Token: 0x06019B80 RID: 105344 RVA: 0x0077BFD0 File Offset: 0x0077A1D0
	public void SetDefaultTarget(FVector defaultTargetOffset, float lerpSpeed, float targetUpdateThreshold)
	{
		this.DefaultTargetOffset.FromUeVector(defaultTargetOffset);
		this.LerpSpeed = lerpSpeed;
		this.TargetUpdateThresholdSquared = targetUpdateThreshold * targetUpdateThreshold;
		if (this.Params.GetHeadNode() == this.Params.GetTailNode())
		{
			this.GetCurrentTargetOffset(this.CurrentTargetOffset);
			this.InTargetLerp = false;
		}
	}

	// Token: 0x06019B81 RID: 105345 RVA: 0x0077C028 File Offset: 0x0077A228
	public long SetBoneToTarget(TArray<string> boneNames, float timeLength)
	{
		long num = this.HandleCount + 1L;
		this.HandleCount = num;
		RotateBonesParams rotateBonesParams = new RotateBonesParams(num, boneNames);
		rotateBonesParams.Set(timeLength, 1f, this.CurrentAlphaMap);
		this.Params.AddTail(rotateBonesParams);
		return rotateBonesParams.Handle;
	}

	// Token: 0x06019B82 RID: 105346 RVA: 0x0077C074 File Offset: 0x0077A274
	public void StopBoneToTarget(long handle, float timeLength)
	{
		DoublyLinkedNode<RotateBonesParams> headNode = this.Params.GetHeadNode();
		for (DoublyLinkedNode<RotateBonesParams> doublyLinkedNode = (headNode != null) ? headNode.Next : null; doublyLinkedNode != null; doublyLinkedNode = doublyLinkedNode.Next)
		{
			RotateBonesParams element = doublyLinkedNode.Element;
			if (element != null && element.Handle == handle)
			{
				doublyLinkedNode.Element.Set(timeLength, 0f, this.CurrentAlphaMap);
				return;
			}
		}
	}

	// Token: 0x06019B83 RID: 105347 RVA: 0x0077C0D4 File Offset: 0x0077A2D4
	public long PauseByNames(TArray<string> boneNames, float startLerpTime)
	{
		long num = this.HandleCount + 1L;
		this.HandleCount = num;
		RotateBonesParams rotateBonesParams = new RotateBonesParams(num, boneNames);
		rotateBonesParams.Set(startLerpTime, 1f, this.PauseAlphaMap);
		this.PauseParams.AddTail(rotateBonesParams);
		return rotateBonesParams.Handle;
	}

	// Token: 0x06019B84 RID: 105348 RVA: 0x0077C120 File Offset: 0x0077A320
	public void ClearPause(long handle, float endLerpTime)
	{
		DoublyLinkedNode<RotateBonesParams> headNode = this.PauseParams.GetHeadNode();
		for (DoublyLinkedNode<RotateBonesParams> doublyLinkedNode = (headNode != null) ? headNode.Next : null; doublyLinkedNode != null; doublyLinkedNode = doublyLinkedNode.Next)
		{
			RotateBonesParams element = doublyLinkedNode.Element;
			if (element != null && element.Handle == handle)
			{
				doublyLinkedNode.Element.Set(endLerpTime, 0f, this.PauseAlphaMap);
				return;
			}
		}
	}

	// Token: 0x06019B85 RID: 105349 RVA: 0x0077C180 File Offset: 0x0077A380
	public void Update(float deltaSeconds)
	{
		DoublyLinkedNode<RotateBonesParams> doublyLinkedNode = this.Params.GetTailNode();
		DoublyLinkedNode<RotateBonesParams> headNode = this.Params.GetHeadNode();
		this.CurrentAlphaMap.Clear();
		if (doublyLinkedNode == headNode)
		{
			return;
		}
		while (doublyLinkedNode != null && doublyLinkedNode != headNode)
		{
			RotateBonesParams element = doublyLinkedNode.Element;
			if (element != null)
			{
				element.GetAndUpdate(deltaSeconds, this.CurrentAlphaMap);
			}
			RotateBonesParams element2 = doublyLinkedNode.Element;
			if (element2 != null && element2.IsEnd())
			{
				this.Params.RemoveThis(doublyLinkedNode);
			}
			doublyLinkedNode = doublyLinkedNode.Pre;
		}
		DoublyLinkedNode<RotateBonesParams> doublyLinkedNode2 = this.PauseParams.GetTailNode();
		DoublyLinkedNode<RotateBonesParams> headNode2 = this.PauseParams.GetHeadNode();
		this.PauseAlphaMap.Clear();
		while (doublyLinkedNode2 != null && doublyLinkedNode2 != headNode2)
		{
			RotateBonesParams element3 = doublyLinkedNode2.Element;
			if (element3 != null)
			{
				element3.GetAndUpdate(deltaSeconds, this.PauseAlphaMap);
			}
			RotateBonesParams element4 = doublyLinkedNode2.Element;
			if (element4 != null && element4.IsEnd())
			{
				this.PauseParams.RemoveThis(doublyLinkedNode2);
			}
			doublyLinkedNode2 = doublyLinkedNode2.Pre;
		}
		this.GetCurrentTargetOffset(this.TmpTargetOffset);
		double num = Vector.DistSquared(this.TmpTargetOffset, this.CurrentTargetOffset);
		if (this.InTargetLerp)
		{
			if (num <= 100.0)
			{
				this.InTargetLerp = false;
			}
		}
		else if (num > (double)this.TargetUpdateThresholdSquared)
		{
			this.InTargetLerp = true;
		}
		if (this.InTargetLerp)
		{
			float num2 = (float)Math.Sqrt(num);
			float num3 = deltaSeconds * this.LerpSpeed;
			if (num3 > num2)
			{
				this.CurrentTargetOffset.DeepCopy(this.TmpTargetOffset);
				return;
			}
			RotateBonesToTargetManager.TmpVector.DeepCopy(this.CurrentTargetOffset);
			Vector.Lerp(RotateBonesToTargetManager.TmpVector, this.TmpTargetOffset, (double)(num3 / num2), this.CurrentTargetOffset);
		}
	}

	// Token: 0x06019B86 RID: 105350 RVA: 0x0077C318 File Offset: 0x0077A518
	public void GetActivateBones(TMap<string, float> outMap)
	{
		outMap.Empty(0);
		foreach (KeyValuePair<string, float> keyValuePair in this.CurrentAlphaMap)
		{
			float num = keyValuePair.Value;
			float num2;
			if (this.PauseAlphaMap.TryGetValue(keyValuePair.Key, out num2))
			{
				num *= 1f - num2;
			}
			if (num != 0f)
			{
				outMap.Add(keyValuePair.Key, num);
			}
		}
	}

	// Token: 0x06019B87 RID: 105351 RVA: 0x0077C3AC File Offset: 0x0077A5AC
	public void GetTargetOffset(ref FVector outVector)
	{
		outVector.Set((float)this.CurrentTargetOffset.X, (float)this.CurrentTargetOffset.Y, (float)this.CurrentTargetOffset.Z);
	}

	// Token: 0x06019B88 RID: 105352 RVA: 0x0077C3D8 File Offset: 0x0077A5D8
	private void GetCurrentTargetOffset(Vector @out)
	{
		bool flag = false;
		if (this.SkillComp != null && this.SkillComp.SkillTarget != null)
		{
			Vector tmpVector = RotateBonesToTargetManager.TmpVector;
			FTransformDouble ftransformDouble = this.SkillComp.GetTargetTransform();
			FVectorDouble location = ftransformDouble.GetLocation();
			tmpVector.FromUeVector(location);
			flag = true;
		}
		if (!flag && this.AiComp != null)
		{
			EntityHandle currentTarget = this.AiComp.AiController.AiHateList.GetCurrentTarget();
			BaseActorComponent baseActorComponent;
			if (currentTarget == null)
			{
				baseActorComponent = null;
			}
			else
			{
				WorldEntity entity = currentTarget.Entity;
				baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent2 = baseActorComponent;
			if (baseActorComponent2 != null)
			{
				RotateBonesToTargetManager.TmpVector.DeepCopy(baseActorComponent2.ActorLocationProxy);
				flag = true;
			}
		}
		if (flag)
		{
			Transform tmpTransform = RotateBonesToTargetManager.TmpTransform;
			FTransformDouble ftransformDouble = this.ActorComp.Actor.Mesh.D_K2_GetComponentToWorld();
			tmpTransform.FromUeTransform(ftransformDouble);
			RotateBonesToTargetManager.TmpTransform.InverseTransformPosition(RotateBonesToTargetManager.TmpVector, @out);
			return;
		}
		@out.DeepCopy(this.DefaultTargetOffset);
	}

	// Token: 0x0400CCDE RID: 52446
	private long HandleCount;

	// Token: 0x0400CCDF RID: 52447
	[Nullable(2)]
	private readonly CharacterSkillComponent SkillComp;

	// Token: 0x0400CCE0 RID: 52448
	[Nullable(2)]
	private readonly CharacterAiComponent AiComp;

	// Token: 0x0400CCE1 RID: 52449
	private readonly DoublyLinkedList<RotateBonesParams> Params = new DoublyLinkedList<RotateBonesParams>(null);

	// Token: 0x0400CCE2 RID: 52450
	private readonly DoublyLinkedList<RotateBonesParams> PauseParams = new DoublyLinkedList<RotateBonesParams>(null);

	// Token: 0x0400CCE3 RID: 52451
	private readonly Dictionary<string, float> CurrentAlphaMap = new Dictionary<string, float>();

	// Token: 0x0400CCE4 RID: 52452
	private readonly Dictionary<string, float> PauseAlphaMap = new Dictionary<string, float>();

	// Token: 0x0400CCE5 RID: 52453
	private readonly Vector CurrentTargetOffset = Vector.Create();

	// Token: 0x0400CCE6 RID: 52454
	private bool InTargetLerp;

	// Token: 0x0400CCE7 RID: 52455
	private readonly Vector DefaultTargetOffset = Vector.Create();

	// Token: 0x0400CCE8 RID: 52456
	private float LerpSpeed = 100f;

	// Token: 0x0400CCE9 RID: 52457
	private float TargetUpdateThresholdSquared = 100f;

	// Token: 0x0400CCEA RID: 52458
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400CCEB RID: 52459
	private readonly Vector TmpTargetOffset = Vector.Create();

	// Token: 0x0400CCEC RID: 52460
	[StaticVariableRuleIgnore]
	private static readonly Transform TmpTransform = Transform.Create();
}
