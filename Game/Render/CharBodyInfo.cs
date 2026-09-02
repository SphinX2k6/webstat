using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004752 RID: 18258
	[NullableContext(2)]
	[Nullable(0)]
	public class CharBodyInfo
	{
		// Token: 0x0602F613 RID: 194067 RVA: 0x00B3D41C File Offset: 0x00B3B61C
		[NullableContext(1)]
		public void Init(string actorName, string skelName, USkeletalMeshComponent skeletalComp, CharMaterialContainer materialContainer, bool useEmptyMaterial = false)
		{
			this.MaterialContainer = materialContainer;
			this.ActorName = actorName;
			this.BodyName = skelName;
			this.BodyType = new ECharacterBodyType?(RenderConfig.GetBodyTypeByName(skelName));
			this.SkeletalComp = skeletalComp;
			this.SkeletalMesh = skeletalComp.SkeletalMesh;
			this.SpecifiedSlotList = new int[4][];
			this.SpecifiedSlotList[0] = Array.Empty<int>();
			this.SpecifiedSlotList[2] = Array.Empty<int>();
			this.SpecifiedSlotList[1] = Array.Empty<int>();
			this.SpecifiedSlotList[3] = Array.Empty<int>();
			TArray<FName> materialSlotNames = skeletalComp.GetMaterialSlotNames();
			int num = materialSlotNames.Num();
			this.MaterialSlotList = new CharMaterialSlot[num];
			int i = 0;
			while (i < num)
			{
				UMaterialInstanceDynamic umaterialInstanceDynamic = null;
				if (useEmptyMaterial)
				{
					goto IL_129;
				}
				UMaterialInterface skeletalMaterialInterface = UKuroRenderingRuntimeBPPluginBPLibrary.GetSkeletalMaterialInterface(skeletalComp.SkeletalMesh, i);
				if (skeletalMaterialInterface == null || !skeletalMaterialInterface.IsValid())
				{
					Singleton<Log>.Instance.Warn(ELogModule.RenderCharacter, ELogAuthor.ZJF, "CharBodyInfo.Init: originalMat is not valid", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					umaterialInstanceDynamic = skeletalComp.CreateDynamicMaterialInstance(i, skeletalMaterialInterface, default(FName));
					if (umaterialInstanceDynamic != null && umaterialInstanceDynamic.IsValid())
					{
						goto IL_129;
					}
					Singleton<Log>.Instance.Warn(ELogModule.RenderCharacter, ELogAuthor.ZJF, "CharBodyInfo.Init: dynamicMaterial is not valid", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				IL_200:
				i++;
				continue;
				IL_129:
				this.MaterialSlotList[i] = new CharMaterialSlot();
				this.MaterialSlotList[i].Init(i, materialSlotNames.Get(i).ToString(), umaterialInstanceDynamic);
				this.SpecifiedSlotList[0] = CharBodyInfo.AppendIndex(this.SpecifiedSlotList[0], i);
				switch (this.MaterialSlotList[i].SlotType)
				{
				case ECharacterSlotType.Body:
				case ECharacterSlotType.HairEyeTransparent:
					this.SpecifiedSlotList[2] = CharBodyInfo.AppendIndex(this.SpecifiedSlotList[2], i);
					this.SpecifiedSlotList[1] = CharBodyInfo.AppendIndex(this.SpecifiedSlotList[1], i);
					goto IL_200;
				case ECharacterSlotType.Outline:
					this.SpecifiedSlotList[3] = CharBodyInfo.AppendIndex(this.SpecifiedSlotList[3], i);
					this.SpecifiedSlotList[1] = CharBodyInfo.AppendIndex(this.SpecifiedSlotList[1], i);
					goto IL_200;
				case ECharacterSlotType.EyeMask:
					goto IL_200;
				default:
					goto IL_200;
				}
			}
			int characterSectionCount = UKuroRenderingRuntimeBPPluginBPLibrary.GetCharacterSectionCount(this.SkeletalMesh);
			this.SectionMainMatIndex = new int[characterSectionCount];
			this.UseAlphaTestMaskCount = new int[characterSectionCount];
			this.UseOutlineStencilMaskCount = new int[characterSectionCount];
			this.UseBattleBitCount = new int[characterSectionCount];
			this.UseBattleMaskBitCount = new int[characterSectionCount];
			for (int j = 0; j < characterSectionCount; j++)
			{
				int characterSectionMaterialIndex = UKuroRenderingRuntimeBPPluginBPLibrary.GetCharacterSectionMaterialIndex(this.SkeletalMesh, j);
				this.MaterialSlotList[characterSectionMaterialIndex].SectionIndex = j;
				this.SectionMainMatIndex[j] = characterSectionMaterialIndex;
				this.UseAlphaTestMaskCount[j] = 0;
				this.UseOutlineStencilMaskCount[j] = 0;
				this.UseBattleBitCount[j] = 0;
				this.UseBattleMaskBitCount[j] = 0;
			}
			this.AlphaTestDirty = true;
			this.OutlineStencilDirty = true;
			this.BattleDirty = true;
			this.BattleMaskDirty = true;
			this.UseAlphaTestCount = 0;
			this.UseOutlineStencilCount = 0;
			this.UseBattleCount = 0;
			this.UseBattleMaskCount = 0;
			string str = this.ActorName + "_" + this.BodyName;
			this.StatUpdateMaterial = Stat.CreateNoFlameGraph("Render_CharBodyInfo_UpdateMaterial_" + str, "", "");
			this.StatUpdateAlphaTest = Stat.CreateNoFlameGraph("Render_CharBodyInfo_UpdateAlphaTest_" + str, "", "");
			this.StatUpdateOutlineStencil = Stat.CreateNoFlameGraph("Render_CharBodyInfo_UpdateOutlineStencil_" + str, "", "");
			this.StatUpdateBattle = Stat.CreateNoFlameGraph("Render_CharBodyInfo_UpdateBattle_" + str, "", "");
			this.StatUpdateBattleMask = Stat.CreateNoFlameGraph("Render_CharBodyInfo_UpdateBattleMask_" + str, "", "");
		}

		// Token: 0x0602F614 RID: 194068 RVA: 0x00B3D7D0 File Offset: 0x00B3B9D0
		[NullableContext(1)]
		private static int[] AppendIndex(int[] array, int index)
		{
			int[] array2 = new int[array.Length + 1];
			array.CopyTo(array2, 0);
			array2[array.Length] = index;
			return array2;
		}

		// Token: 0x0602F615 RID: 194069 RVA: 0x00B3D7F8 File Offset: 0x00B3B9F8
		public unsafe void UseBattleMaskCommon()
		{
			this.UseBattleMaskCount++;
			this.BattleMaskDirty = true;
			if (this.UseBattleMaskCount >= 20)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "Battle类型引用异常，检查UseBattleMask调用情况";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Battle Mask Reference Count", this.UseBattleMaskCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.DebugPrint();
			}
		}

		// Token: 0x0602F616 RID: 194070 RVA: 0x00B3D88C File Offset: 0x00B3BA8C
		public unsafe void UseBattleMask(int sectionIndex)
		{
			int num = this.UseBattleMaskBitCount.Length;
			if (sectionIndex < num)
			{
				this.UseBattleMaskBitCount[sectionIndex]++;
				this.BattleMaskDirty = true;
				if (this.UseBattleMaskBitCount[sectionIndex] >= 20)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.MY;
					string message = "BattleMask类型引用异常，检查UseBattleMask调用情况";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Battle Mask Reference Count", this.UseBattleMaskBitCount[sectionIndex]);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "UseBattleMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}

		// Token: 0x0602F617 RID: 194071 RVA: 0x00B3D9B1 File Offset: 0x00B3BBB1
		public void RevertBattleMaskCommon()
		{
			if (this.UseBattleMaskCount > 0)
			{
				this.UseBattleMaskCount--;
				this.BattleMaskDirty = true;
			}
			this.UpdateBattleMask();
		}

		// Token: 0x0602F618 RID: 194072 RVA: 0x00B3D9D8 File Offset: 0x00B3BBD8
		public unsafe void RevertBattleMask(int sectionIndex)
		{
			int num = this.UseBattleMaskBitCount.Length;
			if (sectionIndex < num)
			{
				if (this.UseBattleMaskBitCount[sectionIndex] > 0)
				{
					this.UseBattleMaskBitCount[sectionIndex]--;
					this.BattleMaskDirty = true;
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "RevertBattleMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}

		// Token: 0x0602F619 RID: 194073 RVA: 0x00B3DA98 File Offset: 0x00B3BC98
		public unsafe void UseBattleCommon()
		{
			this.UseBattleCount++;
			this.BattleDirty = true;
			if (this.UseBattleCount >= 20)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "Battle类型引用异常，检查UseBattleCommon调用情况";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Battle Reference Count", this.UseBattleCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.DebugPrint();
			}
		}

		// Token: 0x0602F61A RID: 194074 RVA: 0x00B3DB2C File Offset: 0x00B3BD2C
		public unsafe void UseBattle(int sectionIndex)
		{
			int num = this.UseBattleBitCount.Length;
			if (sectionIndex < num)
			{
				this.UseBattleBitCount[sectionIndex]++;
				this.BattleDirty = true;
				if (this.UseBattleBitCount[sectionIndex] >= 20)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.MY;
					string message = "Battle类型引用异常，检查UseBattle调用情况";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Battle Reference Count", this.UseBattleBitCount[sectionIndex]);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.DebugPrint();
					return;
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "UseBattle索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}

		// Token: 0x0602F61B RID: 194075 RVA: 0x00B3DC57 File Offset: 0x00B3BE57
		public void RevertBattleCommon()
		{
			if (this.UseBattleCount > 0)
			{
				this.UseBattleCount--;
				this.BattleDirty = true;
			}
			this.UpdateBattle();
		}

		// Token: 0x0602F61C RID: 194076 RVA: 0x00B3DC80 File Offset: 0x00B3BE80
		public unsafe void RevertBattle(int sectionIndex)
		{
			int num = this.UseBattleBitCount.Length;
			if (sectionIndex < num)
			{
				if (this.UseBattleBitCount[sectionIndex] > 0)
				{
					this.UseBattleBitCount[sectionIndex]--;
					this.BattleDirty = true;
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "RevertBattle索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}

		// Token: 0x0602F61D RID: 194077 RVA: 0x00B3DD40 File Offset: 0x00B3BF40
		public unsafe void UseAlphaTestCommon()
		{
			this.UseAlphaTestCount++;
			this.AlphaTestDirty = true;
			if (this.UseAlphaTestCount >= 20)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "AlphaTest类型引用异常，检查UseAlphaTest调用情况";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AlphaTest Reference Count", this.UseAlphaTestCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602F61E RID: 194078 RVA: 0x00B3DDD0 File Offset: 0x00B3BFD0
		public unsafe void UseAlphaTest(int sectionIndex)
		{
			int num = this.UseAlphaTestMaskCount.Length;
			if (sectionIndex < num)
			{
				this.UseAlphaTestMaskCount[sectionIndex]++;
				this.AlphaTestDirty = true;
				if (this.UseAlphaTestMaskCount[sectionIndex] >= 20)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.MY;
					string message = "AlphaTestMask类型引用异常，检查UseAlphaTest调用情况";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AlphaTest Reference Count", this.UseAlphaTestMaskCount[sectionIndex]);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "UseAlphaTestMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}

		// Token: 0x0602F61F RID: 194079 RVA: 0x00B3DEF5 File Offset: 0x00B3C0F5
		public void RevertAlphaTestCommon()
		{
			if (this.UseAlphaTestCount > 0)
			{
				this.UseAlphaTestCount--;
				this.AlphaTestDirty = true;
			}
			this.UpdateAlphaTest();
		}

		// Token: 0x0602F620 RID: 194080 RVA: 0x00B3DF1C File Offset: 0x00B3C11C
		public unsafe void RevertAlphaTest(int sectionIndex)
		{
			int num = this.UseAlphaTestMaskCount.Length;
			if (sectionIndex < num)
			{
				if (this.UseAlphaTestMaskCount[sectionIndex] > 0)
				{
					this.UseAlphaTestMaskCount[sectionIndex]--;
					this.AlphaTestDirty = true;
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "RevertAlphaTestMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}

		// Token: 0x0602F621 RID: 194081 RVA: 0x00B3DFDC File Offset: 0x00B3C1DC
		public unsafe void UseOutlineStencilTestCommon()
		{
			this.UseOutlineStencilCount++;
			this.OutlineStencilDirty = true;
			if (this.UseOutlineStencilCount >= 20)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "StencilOutline类型引用异常，检查UseAlphaTest调用情况";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("StencilOutline Reference Count", this.UseAlphaTestCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602F622 RID: 194082 RVA: 0x00B3E06C File Offset: 0x00B3C26C
		public unsafe void UseOutlineStencilTest(int sectionIndex)
		{
			int num = this.UseOutlineStencilMaskCount.Length;
			if (sectionIndex < num)
			{
				this.UseOutlineStencilMaskCount[sectionIndex]++;
				this.OutlineStencilDirty = true;
				if (this.UseOutlineStencilMaskCount[sectionIndex] >= 20)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.MY;
					string message = "StencilOutlineMask类型引用异常，检查UseStencilOutline调用情况";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("StencilOutline Reference Count", this.UseOutlineStencilMaskCount[sectionIndex]);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "UseStencilOutlineMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
		}

		// Token: 0x0602F623 RID: 194083 RVA: 0x00B3E191 File Offset: 0x00B3C391
		public void RevertOutlineStencilTestCommon()
		{
			if (this.UseOutlineStencilCount > 0)
			{
				this.UseOutlineStencilCount--;
				this.OutlineStencilDirty = true;
			}
			this.UpdateStencilOutlineTest();
		}

		// Token: 0x0602F624 RID: 194084 RVA: 0x00B3E1B8 File Offset: 0x00B3C3B8
		public unsafe void RevertOutlineStencilTest(int sectionIndex)
		{
			int num = this.UseOutlineStencilMaskCount.Length;
			if (sectionIndex < num)
			{
				if (this.UseOutlineStencilMaskCount[sectionIndex] > 0)
				{
					this.UseOutlineStencilMaskCount[sectionIndex]--;
					this.OutlineStencilDirty = true;
					return;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "RevertOutlineStencilMask索引超过最大值";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("索引", sectionIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("最大值", num - 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Actor", this.ActorName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}

		// Token: 0x0602F625 RID: 194085 RVA: 0x00B3E278 File Offset: 0x00B3C478
		public void SetColor(FName propertyName, FLinearColor color, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].SetColor(propertyName, color);
			}
		}

		// Token: 0x0602F626 RID: 194086 RVA: 0x00B3E2B0 File Offset: 0x00B3C4B0
		public void RevertColor(FName propertyName, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			string propertyStr = propertyName.ToString();
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].RevertColor(propertyStr);
			}
		}

		// Token: 0x0602F627 RID: 194087 RVA: 0x00B3E2F4 File Offset: 0x00B3C4F4
		public void SetFloat(FName propertyName, float value, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].SetFloat(propertyName, value);
			}
		}

		// Token: 0x0602F628 RID: 194088 RVA: 0x00B3E32C File Offset: 0x00B3C52C
		public void RevertFloat(FName propertyName, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			string propertyStr = propertyName.ToString();
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].RevertFloat(propertyStr);
			}
		}

		// Token: 0x0602F629 RID: 194089 RVA: 0x00B3E370 File Offset: 0x00B3C570
		[NullableContext(1)]
		public void SetTexture(FName propertyName, UTexture texture, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].SetTexture(propertyName, texture);
			}
		}

		// Token: 0x0602F62A RID: 194090 RVA: 0x00B3E3A8 File Offset: 0x00B3C5A8
		public void RevertTexture(FName propertyName, ECharacterSlotSpecifiedType specifiedSlotType)
		{
			int[] array = this.SpecifiedSlotList[(int)specifiedSlotType];
			int num = array.Length;
			string propertyStr = propertyName.ToString();
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[array[i]].RevertTexture(propertyStr);
			}
		}

		// Token: 0x0602F62B RID: 194091 RVA: 0x00B3E3EC File Offset: 0x00B3C5EC
		public void SetStarScarEnergy(float value)
		{
			int num = this.MaterialSlotList.Length;
			for (int i = 0; i < num; i++)
			{
				this.MaterialSlotList[i].SetStarScarEnergy(value);
			}
		}

		// Token: 0x0602F62C RID: 194092 RVA: 0x00B3E41C File Offset: 0x00B3C61C
		public void SetNoWater(bool value)
		{
			if (this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetDisableWaterForToon(value);
			}
		}

		// Token: 0x0602F62D RID: 194093 RVA: 0x00B3E440 File Offset: 0x00B3C640
		public int Update(EMaterialShadingRate? meshShadingRate = null)
		{
			if (meshShadingRate != null && this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetMeshShadingRate(meshShadingRate.Value);
			}
			int result = this.UpdateMaterial();
			this.UpdateAlphaTest();
			this.UpdateStencilOutlineTest();
			this.UpdateBattle();
			this.UpdateBattleMask();
			return result;
		}

		// Token: 0x0602F62E RID: 194094 RVA: 0x00B3E49C File Offset: 0x00B3C69C
		public void ResetAllState()
		{
			this.AlphaTestDirty = true;
			this.OutlineStencilDirty = true;
			this.UseAlphaTestCount = 0;
			this.UseOutlineStencilCount = 0;
			this.UseAlphaTestMaskCount.AsSpan<int>().Fill(0);
			this.UseOutlineStencilMaskCount.AsSpan<int>().Fill(0);
			this.UseBattleBitCount.AsSpan<int>().Fill(0);
			this.UseBattleMaskBitCount.AsSpan<int>().Fill(0);
			this.UseOutlineStencilMaskCount.AsSpan<int>().Fill(0);
			this.UpdateAlphaTest();
			this.UpdateStencilOutlineTest();
			this.UpdateBattle();
			this.UpdateBattleMask();
		}

		// Token: 0x0602F62F RID: 194095 RVA: 0x00B3E544 File Offset: 0x00B3C744
		private void DebugPrint()
		{
			CharMaterialController charMaterialController = this.MaterialContainer.GetRenderingComponent().GetComponent(2) as CharMaterialController;
			if (charMaterialController != null)
			{
				charMaterialController.PrintCurrentInfo();
			}
		}

		// Token: 0x0602F630 RID: 194096 RVA: 0x00B3E574 File Offset: 0x00B3C774
		private int UpdateMaterial()
		{
			if (this.SkeletalComp == null || !this.SkeletalComp.IsValid())
			{
				return 0;
			}
			int num = 0;
			int num2 = this.MaterialSlotList.Length;
			for (int i = 0; i < num2; i++)
			{
				CharMaterialSlot charMaterialSlot = this.MaterialSlotList[i];
				num += charMaterialSlot.UpdateMaterialParam();
				charMaterialSlot.SetSkeletalMeshMaterial(this.SkeletalComp);
			}
			return num;
		}

		// Token: 0x0602F631 RID: 194097 RVA: 0x00B3E5D0 File Offset: 0x00B3C7D0
		public void UpdateBattleMask()
		{
			if (!this.BattleMaskDirty)
			{
				return;
			}
			this.BattleMaskDirty = false;
			TArray<int> tarray = new TArray<int>();
			bool flag;
			bool useSectionMask;
			if (this.UseBattleMaskCount > 0)
			{
				flag = true;
				useSectionMask = false;
			}
			else
			{
				int num = this.UseBattleMaskBitCount.Length;
				for (int i = 0; i < num; i++)
				{
					if (this.UseBattleMaskBitCount[i] > 0)
					{
						tarray.Add(i);
					}
				}
				flag = (tarray.Num() > 0);
				useSectionMask = flag;
			}
			if (this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetUseEnableBattleMask(flag);
				this.SkeletalComp.SetUseEnableBattleMaskSectionMask(useSectionMask, tarray);
			}
		}

		// Token: 0x0602F632 RID: 194098 RVA: 0x00B3E670 File Offset: 0x00B3C870
		public void UpdateBattle()
		{
			if (!this.BattleDirty)
			{
				return;
			}
			this.BattleDirty = false;
			TArray<int> tarray = new TArray<int>();
			bool flag;
			bool useSectionMask;
			if (this.UseBattleCount > 0)
			{
				flag = true;
				useSectionMask = false;
			}
			else
			{
				int num = this.UseBattleBitCount.Length;
				for (int i = 0; i < num; i++)
				{
					if (this.UseBattleBitCount[i] > 0)
					{
						tarray.Add(i);
					}
				}
				flag = (tarray.Num() > 0);
				useSectionMask = flag;
			}
			if (this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetUseEnableBattle(flag);
				this.SkeletalComp.SetUseEnableBattleSectionMask(useSectionMask, tarray);
			}
		}

		// Token: 0x0602F633 RID: 194099 RVA: 0x00B3E710 File Offset: 0x00B3C910
		public void UpdateAlphaTest()
		{
			if (!this.AlphaTestDirty)
			{
				return;
			}
			this.AlphaTestDirty = false;
			TArray<int> tarray = new TArray<int>();
			bool flag;
			bool useSectionMask;
			if (this.UseAlphaTestCount > 0)
			{
				flag = true;
				useSectionMask = false;
			}
			else
			{
				int num = this.UseAlphaTestMaskCount.Length;
				for (int i = 0; i < num; i++)
				{
					if (this.UseAlphaTestMaskCount[i] > 0)
					{
						tarray.Add(i);
					}
				}
				flag = (tarray.Num() > 0);
				useSectionMask = flag;
			}
			if (this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetUseCustomAlphaTest(flag);
				this.SkeletalComp.SetUseCustomAlphaTestSectionMask(useSectionMask, tarray);
			}
		}

		// Token: 0x0602F634 RID: 194100 RVA: 0x00B3E7B0 File Offset: 0x00B3C9B0
		public void UpdateStencilOutlineTest()
		{
			if (!this.OutlineStencilDirty)
			{
				return;
			}
			this.OutlineStencilDirty = false;
			TArray<int> tarray = new TArray<int>();
			bool flag;
			bool useSectionMask;
			if (this.UseOutlineStencilCount > 0)
			{
				flag = true;
				useSectionMask = false;
			}
			else
			{
				int num = this.UseOutlineStencilMaskCount.Length;
				for (int i = 0; i < num; i++)
				{
					if (this.UseOutlineStencilMaskCount[i] > 0)
					{
						tarray.Add(i);
					}
				}
				flag = (tarray.Num() > 0);
				useSectionMask = flag;
			}
			if (this.SkeletalComp != null && this.SkeletalComp.IsValid())
			{
				this.SkeletalComp.SetUseOutlineStencilTest(flag);
				this.SkeletalComp.SetUseOutlineStencilTestSectionMask(useSectionMask, tarray);
			}
		}

		// Token: 0x0401AFA1 RID: 110497
		[Nullable(1)]
		public string ActorName = string.Empty;

		// Token: 0x0401AFA2 RID: 110498
		[Nullable(1)]
		public string BodyName = string.Empty;

		// Token: 0x0401AFA3 RID: 110499
		public ECharacterBodyType? BodyType;

		// Token: 0x0401AFA4 RID: 110500
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public CharMaterialSlot[] MaterialSlotList;

		// Token: 0x0401AFA5 RID: 110501
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public int[][] SpecifiedSlotList;

		// Token: 0x0401AFA6 RID: 110502
		public USkeletalMeshComponent SkeletalComp;

		// Token: 0x0401AFA7 RID: 110503
		public USkeletalMesh SkeletalMesh;

		// Token: 0x0401AFA8 RID: 110504
		private int[] SectionMainMatIndex;

		// Token: 0x0401AFA9 RID: 110505
		private bool AlphaTestDirty;

		// Token: 0x0401AFAA RID: 110506
		private bool OutlineStencilDirty;

		// Token: 0x0401AFAB RID: 110507
		private bool BattleDirty;

		// Token: 0x0401AFAC RID: 110508
		private bool BattleMaskDirty;

		// Token: 0x0401AFAD RID: 110509
		private int UseAlphaTestCount;

		// Token: 0x0401AFAE RID: 110510
		private int UseOutlineStencilCount;

		// Token: 0x0401AFAF RID: 110511
		private int UseBattleCount;

		// Token: 0x0401AFB0 RID: 110512
		private int UseBattleMaskCount;

		// Token: 0x0401AFB1 RID: 110513
		private int[] UseAlphaTestMaskCount;

		// Token: 0x0401AFB2 RID: 110514
		private int[] UseOutlineStencilMaskCount;

		// Token: 0x0401AFB3 RID: 110515
		private int[] UseBattleBitCount;

		// Token: 0x0401AFB4 RID: 110516
		private int[] UseBattleMaskBitCount;

		// Token: 0x0401AFB5 RID: 110517
		private Stat StatUpdateMaterial;

		// Token: 0x0401AFB6 RID: 110518
		private Stat StatUpdateAlphaTest;

		// Token: 0x0401AFB7 RID: 110519
		private Stat StatUpdateBattle;

		// Token: 0x0401AFB8 RID: 110520
		private Stat StatUpdateBattleMask;

		// Token: 0x0401AFB9 RID: 110521
		private Stat StatUpdateOutlineStencil;

		// Token: 0x0401AFBA RID: 110522
		private CharMaterialContainer MaterialContainer;

		// Token: 0x0401AFBB RID: 110523
		public int LastUpdateCounter;
	}
}
