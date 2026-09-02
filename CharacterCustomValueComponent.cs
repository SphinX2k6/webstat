using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02003036 RID: 12342
[NullableContext(1)]
[Nullable(0)]
public class CharacterCustomValueComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x060193CD RID: 103373 RVA: 0x00739B44 File Offset: 0x00737D44
	static CharacterCustomValueComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterCustomValueComponent.CreateStaticDefaultValue), new Action(CharacterCustomValueComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002204 RID: 8708
	// (get) Token: 0x060193CE RID: 103374 RVA: 0x00739B63 File Offset: 0x00737D63
	private static Dictionary<string, Func<TFormulaValue[], TFormulaValue>> BuiltinFormulaFunctions
	{
		get
		{
			Dictionary<string, Func<TFormulaValue[], TFormulaValue>> builtinFormulaFunctions = CharacterCustomValueComponent._builtinFormulaFunctions;
			if (builtinFormulaFunctions == null)
			{
				throw new InvalidOperationException("BuiltinFormulaFunctions is not initialized.");
			}
			return builtinFormulaFunctions;
		}
	}

	// Token: 0x060193CF RID: 103375 RVA: 0x00739B7C File Offset: 0x00737D7C
	protected override bool OnStart()
	{
		UClassStackOnlyPtr @class = base.Entity.GetComponent<CharacterActorComponent>().Actor.GetClass();
		TSoftClassPtr<UObject> tsoftClassPtr = UKismetSystemLibrary.Conv_ClassToSoftClassReference(@class);
		string characterResourcePath = UKismetSystemLibrary.Conv_SoftClassReferenceToString(tsoftClassPtr);
		SCharacterFightInfo characterFightInfo = ConfigBase<WorldConfig>.Instance.GetCharacterFightInfo(characterResourcePath);
		string text = (characterFightInfo != null) ? characterFightInfo.CustomParamTable.ToAssetPathName() : null;
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>(text, new Action<UDataTable, string>(this.OnLoadCustomValueFinish), 100, "js_undefined");
		this.OnStartBuiltinFunctions();
		return true;
	}

	// Token: 0x060193D0 RID: 103376 RVA: 0x00739BFC File Offset: 0x00737DFC
	private unsafe void OnLoadCustomValueFinish([Nullable(2)] UDataTable asset, string path)
	{
		if (asset == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "[自定义值]CDT_CharacterFightInfo中的路径配置的表路径找不到资源";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			BaseActorComponent component = base.Entity.GetComponent<BaseActorComponent>();
			ptr = new ValueTuple<string, object>(item, (component != null) ? component.Owner : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", path);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.AssetDataTable = asset;
		List<DataTableKeyRow<SCustomValueRecordRow>> list = new List<DataTableKeyRow<SCustomValueRecordRow>>();
		DataTableUtil.GetDataTableAllRowWithKeysFromTable<SCustomValueRecordRow>(this.AssetDataTable, list);
		foreach (DataTableKeyRow<SCustomValueRecordRow> dataTableKeyRow in list)
		{
			string key = dataTableKeyRow.Key;
			if (string.IsNullOrEmpty(key))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.HCW;
				string message2 = "[自定义值]配置错误 key是空的";
				string item2 = "Actor";
				BaseActorComponent component2 = base.Entity.GetComponent<BaseActorComponent>();
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item2, (component2 != null) ? component2.Owner : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				SCustomValueRecordRow value = dataTableKeyRow.Value;
				if (value == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Battle;
					ELogAuthor author3 = ELogAuthor.HCW;
					string message3 = "[自定义值]配置错误 value是空的";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Key", key);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item3 = "Actor";
					BaseActorComponent component3 = base.Entity.GetComponent<BaseActorComponent>();
					ptr2 = new ValueTuple<string, object>(item3, (component3 != null) ? component3.Owner : null);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				else
				{
					this.MapCustomValue[key] = value;
					if (value.NumSource == ECustomValueSourceNum.固定值 && value.ReturnType == ECustomValueReturn.数字)
					{
						this.Blackboard[key] = TFormulaValue.FromDouble((double)value.NumberValue.Get(0));
					}
					else if (value.VecSource == ECustomValueSourceVector.固定值 && value.ReturnType == ECustomValueReturn.向量)
					{
						this.Blackboard[key] = TFormulaValue.FromVector(Vector.Create(value.VectorValue.Get(0)));
					}
					else if (value.RotSource == ECustomValueSourceRotator.固定值 && value.ReturnType == ECustomValueReturn.旋转)
					{
						this.Blackboard[key] = TFormulaValue.FromRotator(Rotator.Create(value.RotatorValue.Get(0)));
					}
				}
			}
		}
	}

	// Token: 0x060193D1 RID: 103377 RVA: 0x00739EB4 File Offset: 0x007380B4
	private void OnStartBuiltinFunctions()
	{
		if (CharacterCustomValueComponent.BuiltinFormulaFunctions.Count > 0)
		{
			return;
		}
		CharacterCustomValueComponent.BuiltinFormulaFunctions["MClamp"] = delegate(TFormulaValue[] args)
		{
			double currentValue = (double)args[0];
			double min = (double)args[1];
			double max = (double)args[2];
			return TFormulaValue.FromDouble(Singleton<MathUtils>.Instance.Clamp(currentValue, min, max));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["MMax"] = delegate(TFormulaValue[] args)
		{
			if (args.Length == 0)
			{
				return TFormulaValue.FromDouble(0.0);
			}
			double num = (double)args[0];
			for (int i = 1; i < args.Length; i++)
			{
				double num2 = (double)args[i];
				if (num2 > num)
				{
					num = num2;
				}
			}
			return TFormulaValue.FromDouble(num);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["MMin"] = delegate(TFormulaValue[] args)
		{
			if (args.Length == 0)
			{
				return TFormulaValue.FromDouble(0.0);
			}
			double num = (double)args[0];
			for (int i = 1; i < args.Length; i++)
			{
				double num2 = (double)args[i];
				if (num2 < num)
				{
					num = num2;
				}
			}
			return TFormulaValue.FromDouble(num);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VAdd"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Vector vector2 = Vector.Create();
			Vector vector3;
			if (args[1].TryGetVector(out vector3) && vector3 != null)
			{
				vector.Addition(vector3, vector2);
			}
			else
			{
				vector.Addition((double)args[1], vector2);
			}
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VSub"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Vector vector2 = Vector.Create();
			Vector vector3;
			if (args[1].TryGetVector(out vector3) && vector3 != null)
			{
				vector.Subtraction(vector3, vector2);
			}
			else
			{
				vector.Subtraction((double)args[1], vector2);
			}
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VMulti"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Vector vector2 = Vector.Create();
			Vector vector3;
			if (args[1].TryGetVector(out vector3) && vector3 != null)
			{
				vector.Multiply(vector3, vector2);
			}
			else
			{
				vector.Multiply((double)args[1], vector2);
			}
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDiv"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Vector vector2 = Vector.Create();
			Vector vector3;
			if (args[1].TryGetVector(out vector3) && vector3 != null)
			{
				vector.Division(vector3, vector2);
			}
			else
			{
				vector.Division((double)args[1], vector2);
			}
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDotProduct"] = delegate(TFormulaValue[] args)
		{
			Vector inA = (Vector)args[0];
			Vector inB = (Vector)args[1];
			return TFormulaValue.FromDouble(Vector.DotProduct(inA, inB));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VCrossProduct"] = delegate(TFormulaValue[] args)
		{
			Vector inA = (Vector)args[0];
			Vector inB = (Vector)args[1];
			Vector vector = Vector.Create();
			Vector.CrossProduct(inA, inB, vector);
			return TFormulaValue.FromVector(vector);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VNormal"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Vector vector2 = Vector.Create();
			vector.GetSafeNormal(vector2, 9.99999993922529E-09);
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDist"] = delegate(TFormulaValue[] args)
		{
			Vector v = (Vector)args[0];
			Vector v2 = (Vector)args[1];
			return TFormulaValue.FromDouble(Vector.Dist(v, v2));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDistXY"] = delegate(TFormulaValue[] args)
		{
			Vector v = (Vector)args[0];
			Vector v2 = (Vector)args[1];
			return TFormulaValue.FromDouble(Vector.DistXY(v, v2));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDistSquared"] = delegate(TFormulaValue[] args)
		{
			Vector v = (Vector)args[0];
			Vector v2 = (Vector)args[1];
			return TFormulaValue.FromDouble(Vector.DistSquared(v, v2));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VDistSquaredXY"] = delegate(TFormulaValue[] args)
		{
			Vector v = (Vector)args[0];
			Vector v2 = (Vector)args[1];
			return TFormulaValue.FromDouble(Vector.DistSquaredXY(v, v2));
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VGetClampedToSize"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			double min = (double)args[1];
			double max = (double)args[2];
			Vector vector2 = Vector.Create();
			vector.GetClampedToSize(min, max, vector2);
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VGetClampedToSize2D"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			double min = (double)args[1];
			double max = (double)args[2];
			Vector vector2 = Vector.Create();
			vector.GetClampedToSize2D(min, max, vector2);
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VMax"] = ((TFormulaValue[] args) => TFormulaValue.FromDouble(((Vector)args[0]).GetMax()));
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VMin"] = ((TFormulaValue[] args) => TFormulaValue.FromDouble(((Vector)args[0]).GetMin()));
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VAbsMax"] = ((TFormulaValue[] args) => TFormulaValue.FromDouble(((Vector)args[0]).GetAbsMax()));
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VAbsMin"] = ((TFormulaValue[] args) => TFormulaValue.FromDouble(((Vector)args[0]).GetAbsMin()));
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VRotation"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			Rotator rotator = Rotator.Create();
			vector.Rotation(rotator);
			return TFormulaValue.FromRotator(rotator);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VSetX"] = delegate(TFormulaValue[] args)
		{
			IVector inV = (Vector)args[0];
			double x = (double)args[1];
			Vector vector = Vector.Create(inV);
			vector.X = x;
			return TFormulaValue.FromVector(vector);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VSetY"] = delegate(TFormulaValue[] args)
		{
			IVector inV = (Vector)args[0];
			double y = (double)args[1];
			Vector vector = Vector.Create(inV);
			vector.Y = y;
			return TFormulaValue.FromVector(vector);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VSetZ"] = delegate(TFormulaValue[] args)
		{
			IVector inV = (Vector)args[0];
			double z = (double)args[1];
			Vector vector = Vector.Create(inV);
			vector.Z = z;
			return TFormulaValue.FromVector(vector);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["VRotateAngleAxis"] = delegate(TFormulaValue[] args)
		{
			Vector vector = (Vector)args[0];
			double angleDeg = (double)args[1];
			Vector axis = (Vector)args[2];
			Vector vector2 = Vector.Create();
			vector.RotateAngleAxis(angleDeg, axis, vector2);
			return TFormulaValue.FromVector(vector2);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["RAdd"] = delegate(TFormulaValue[] args)
		{
			Rotator inR = (Rotator)args[0];
			Rotator inB = (Rotator)args[1];
			Rotator rotator = Rotator.Create();
			rotator.FromUeRotator(inR);
			rotator.AdditionEqual(inB);
			return TFormulaValue.FromRotator(rotator);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["RSub"] = delegate(TFormulaValue[] args)
		{
			Rotator inR = (Rotator)args[0];
			Rotator inB = (Rotator)args[1];
			Rotator rotator = Rotator.Create();
			rotator.FromUeRotator(inR);
			rotator.SubtractionEqual(inB);
			return TFormulaValue.FromRotator(rotator);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["RMulti"] = delegate(TFormulaValue[] args)
		{
			Rotator inR = (Rotator)args[0];
			float inV = (float)((double)args[1]);
			Rotator rotator = Rotator.Create();
			rotator.FromUeRotator(inR);
			rotator.MultiplyEqual(inV);
			return TFormulaValue.FromRotator(rotator);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["RVector"] = delegate(TFormulaValue[] args)
		{
			Rotator rotator = (Rotator)args[0];
			Vector vector = Vector.Create();
			rotator.Vector(vector);
			return TFormulaValue.FromVector(vector);
		};
		CharacterCustomValueComponent.BuiltinFormulaFunctions["IsNull"] = delegate(TFormulaValue[] args)
		{
			string key = (string)args[0];
			return TFormulaValue.FromBool(!this.Blackboard.ContainsKey(key) || this.Blackboard[key].IsNull);
		};
	}

	// Token: 0x060193D2 RID: 103378 RVA: 0x0073A420 File Offset: 0x00738620
	private Dictionary<string, TFormulaValue> BuildFormulaArgs()
	{
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		foreach (KeyValuePair<string, TFormulaValue> keyValuePair in this.Blackboard)
		{
			if (!keyValuePair.Value.IsNull)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		return dictionary;
	}

	// Token: 0x060193D3 RID: 103379 RVA: 0x0073A498 File Offset: 0x00738698
	public unsafe TFormulaValue GetBlackboard(string key, TFormulaValue defaultValue = default(TFormulaValue))
	{
		if (GlobalData.IsPlayInEditor)
		{
			SCustomValueRecordRow scustomValueRecordRow;
			if (!this.MapCustomValue.TryGetValue(key, out scustomValueRecordRow))
			{
				if (!defaultValue.IsNull)
				{
					return defaultValue;
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "[自定义值]AN配置的key在DT表中找不到对应的行";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", key);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "Actor";
				BaseActorComponent component = base.Entity.GetComponent<BaseActorComponent>();
				ptr = new ValueTuple<string, object>(item, (component != null) ? component.Owner : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return default(TFormulaValue);
			}
			else
			{
				if (scustomValueRecordRow.ReturnType == ECustomValueReturn.数字 && scustomValueRecordRow.NumSource == ECustomValueSourceNum.固定值)
				{
					return TFormulaValue.FromDouble((double)scustomValueRecordRow.NumberValue.Get(0));
				}
				if (scustomValueRecordRow.ReturnType == ECustomValueReturn.向量 && scustomValueRecordRow.VecSource == ECustomValueSourceVector.固定值)
				{
					return TFormulaValue.FromVector(Vector.Create(scustomValueRecordRow.VectorValue.Get(0)));
				}
				if (scustomValueRecordRow.ReturnType == ECustomValueReturn.旋转 && scustomValueRecordRow.RotSource == ECustomValueSourceRotator.固定值)
				{
					return TFormulaValue.FromRotator(Rotator.Create(scustomValueRecordRow.RotatorValue.Get(0)));
				}
			}
		}
		TFormulaValue result;
		if (this.Blackboard.TryGetValue(key, out result) && !result.IsNull)
		{
			return result;
		}
		if (!defaultValue.IsNull)
		{
			return defaultValue;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Bullet;
		ELogAuthor author2 = ELogAuthor.HCW;
		string message2 = "[自定义值]Blackboard值获取不到";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", key);
		instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return result;
	}

	// Token: 0x060193D4 RID: 103380 RVA: 0x0073A64C File Offset: 0x0073884C
	public unsafe void UpdateCustomValue(string key)
	{
		SCustomValueRecordRow scustomValueRecordRow;
		if (!this.MapCustomValue.TryGetValue(key, out scustomValueRecordRow))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "[自定义值]AN配置的key在DT表中找不到对应的行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", key);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Actor";
			BaseActorComponent component = base.Entity.GetComponent<BaseActorComponent>();
			ptr = new ValueTuple<string, object>(item, (component != null) ? component.Owner : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		TFormulaValue value = default(TFormulaValue);
		if ((scustomValueRecordRow.ReturnType == ECustomValueReturn.数字 && scustomValueRecordRow.NumSource == ECustomValueSourceNum.固定值) || (scustomValueRecordRow.ReturnType == ECustomValueReturn.向量 && scustomValueRecordRow.VecSource == ECustomValueSourceVector.固定值) || (scustomValueRecordRow.ReturnType == ECustomValueReturn.旋转 && scustomValueRecordRow.RotSource == ECustomValueSourceRotator.固定值))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.HCW;
			string message2 = "[自定义值]固定值不能更新值";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Key", key);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
			string item2 = "Actor";
			BaseActorComponent component2 = base.Entity.GetComponent<BaseActorComponent>();
			ptr2 = new ValueTuple<string, object>(item2, (component2 != null) ? component2.Owner : null);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		if ((scustomValueRecordRow.ReturnType == ECustomValueReturn.数字 && scustomValueRecordRow.NumSource == ECustomValueSourceNum.表达式) || (scustomValueRecordRow.ReturnType == ECustomValueReturn.向量 && scustomValueRecordRow.VecSource == ECustomValueSourceVector.表达式) || (scustomValueRecordRow.ReturnType == ECustomValueReturn.旋转 && scustomValueRecordRow.RotSource == ECustomValueSourceRotator.表达式))
		{
			int num = scustomValueRecordRow.FormulaList.Num();
			for (int i = 0; i < num; i++)
			{
				SCustomValueFormula scustomValueFormula = scustomValueRecordRow.FormulaList.Get(i);
				bool flag = true;
				if (!StringUtils.IsEmpty(scustomValueFormula.Condition))
				{
					Formula formula = new Formula(scustomValueFormula.Condition).SetBuiltinFunctions(CharacterCustomValueComponent.BuiltinFormulaFunctions);
					try
					{
						flag = (bool)formula.Evaluate(this.BuildFormulaArgs(), null);
					}
					catch (Exception ex)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Battle;
						ELogAuthor author3 = ELogAuthor.HCW;
						string message3 = "[自定义值]条件表达式计算出现异常";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Key", key);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("表达式序号", i);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("表达式", scustomValueFormula.Condition);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("Value", ex.Message);
						instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
					}
					finally
					{
						formula.Dispose();
					}
				}
				if (flag)
				{
					Formula formula2 = new Formula(scustomValueFormula.Value).SetBuiltinFunctions(CharacterCustomValueComponent.BuiltinFormulaFunctions);
					try
					{
						value = formula2.Evaluate(this.BuildFormulaArgs(), null);
						if (value.IsNull)
						{
							Log instance4 = Singleton<Log>.Instance;
							ELogModule module4 = ELogModule.Battle;
							ELogAuthor author4 = ELogAuthor.HCW;
							string message4 = "[自定义值]取值失败";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Key", key);
							ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1);
							string item3 = "Actor";
							BaseActorComponent component3 = base.Entity.GetComponent<BaseActorComponent>();
							ptr3 = new ValueTuple<string, object>(item3, (component3 != null) ? component3.Owner : null);
							instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
							return;
						}
						this.Blackboard[key] = value;
					}
					catch (Exception ex2)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Battle;
						ELogAuthor author5 = ELogAuthor.HCW;
						string message5 = "[自定义值]表达式计算出现异常";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Key", key);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("表达式序号", i);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("表达式", scustomValueFormula.Value);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("Value", ex2.Message);
						instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 4));
					}
					finally
					{
						formula2.Dispose();
					}
					if (!scustomValueFormula.IsContinueFormula)
					{
						break;
					}
				}
			}
			return;
		}
		if (scustomValueRecordRow.ReturnType == ECustomValueReturn.向量)
		{
			if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者位置)
			{
				BaseActorComponent component4 = base.Entity.GetComponent<BaseActorComponent>();
				value = TFormulaValue.FromVector(Vector.Create((component4 != null) ? component4.ActorLocationProxy : null));
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.技能目标位置)
			{
				CharacterSkillComponent component5 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle = (component5 != null) ? component5.SkillTarget : null;
				if (entityHandle == null || !entityHandle.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				BaseActorComponent component6 = entityHandle.Entity.GetComponent<BaseActorComponent>();
				value = TFormulaValue.FromVector(Vector.Create((component6 != null) ? component6.ActorLocationProxy : null));
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者朝技能目标标准向量)
			{
				CharacterSkillComponent component7 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle2 = (component7 != null) ? component7.SkillTarget : null;
				if (entityHandle2 == null || !entityHandle2.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				Vector actorLocationProxy = entityHandle2.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
				Vector actorLocationProxy2 = base.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
				Vector vector = Vector.Create();
				actorLocationProxy.Subtraction(actorLocationProxy2, vector);
				vector.Normalize(9.99999993922529E-09);
				value = TFormulaValue.FromVector(vector);
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者朝技能目标水平标准向量)
			{
				CharacterSkillComponent component8 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle3 = (component8 != null) ? component8.SkillTarget : null;
				if (entityHandle3 == null || !entityHandle3.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				Vector actorLocationProxy3 = entityHandle3.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
				Vector actorLocationProxy4 = base.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
				Vector vector2 = Vector.Create();
				actorLocationProxy3.Subtraction(actorLocationProxy4, vector2);
				vector2.Z = 0.0;
				vector2.Normalize(9.99999993922529E-09);
				value = TFormulaValue.FromVector(vector2);
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者前向量)
			{
				BaseActorComponent component9 = base.Entity.GetComponent<BaseActorComponent>();
				Vector vector3 = (component9 != null) ? component9.ActorForwardProxy : null;
				if (vector3 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector3));
				}
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者右向量)
			{
				BaseActorComponent component10 = base.Entity.GetComponent<BaseActorComponent>();
				Vector vector4 = (component10 != null) ? component10.ActorRightProxy : null;
				if (vector4 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector4));
				}
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.使用者上向量)
			{
				BaseActorComponent component11 = base.Entity.GetComponent<BaseActorComponent>();
				Vector vector5 = (component11 != null) ? component11.ActorUpProxy : null;
				if (vector5 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector5));
				}
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.技能目标前向量)
			{
				CharacterSkillComponent component12 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle4 = (component12 != null) ? component12.SkillTarget : null;
				if (entityHandle4 == null || !entityHandle4.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				BaseActorComponent component13 = entityHandle4.Entity.GetComponent<BaseActorComponent>();
				Vector vector6 = (component13 != null) ? component13.ActorForwardProxy : null;
				if (vector6 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector6));
				}
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.技能目标右向量)
			{
				CharacterSkillComponent component14 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle5 = (component14 != null) ? component14.SkillTarget : null;
				if (entityHandle5 == null || !entityHandle5.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				BaseActorComponent component15 = entityHandle5.Entity.GetComponent<BaseActorComponent>();
				Vector vector7 = (component15 != null) ? component15.ActorRightProxy : null;
				if (vector7 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector7));
				}
			}
			else if (scustomValueRecordRow.VecSource == ECustomValueSourceVector.技能目标上向量)
			{
				CharacterSkillComponent component16 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle6 = (component16 != null) ? component16.SkillTarget : null;
				if (entityHandle6 == null || !entityHandle6.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				BaseActorComponent component17 = entityHandle6.Entity.GetComponent<BaseActorComponent>();
				Vector vector8 = (component17 != null) ? component17.ActorUpProxy : null;
				if (vector8 != null)
				{
					value = TFormulaValue.FromVector(Vector.Create(vector8));
				}
			}
		}
		else if (scustomValueRecordRow.ReturnType == ECustomValueReturn.旋转)
		{
			if (scustomValueRecordRow.RotSource == ECustomValueSourceRotator.使用者朝向)
			{
				BaseActorComponent component18 = base.Entity.GetComponent<BaseActorComponent>();
				value = TFormulaValue.FromRotator(Rotator.Create((component18 != null) ? component18.ActorRotationProxy : null));
			}
			else if (scustomValueRecordRow.RotSource == ECustomValueSourceRotator.技能目标朝向)
			{
				CharacterSkillComponent component19 = base.Entity.GetComponent<CharacterSkillComponent>();
				EntityHandle entityHandle7 = (component19 != null) ? component19.SkillTarget : null;
				if (entityHandle7 == null || !entityHandle7.Valid)
				{
					this.Blackboard[key] = default(TFormulaValue);
					return;
				}
				BaseActorComponent component20 = entityHandle7.Entity.GetComponent<BaseActorComponent>();
				value = TFormulaValue.FromRotator(Rotator.Create((component20 != null) ? component20.ActorRotationProxy : null));
			}
		}
		if (value.IsNull)
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.Battle;
			ELogAuthor author6 = ELogAuthor.HCW;
			string message6 = "[自定义值]取值失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("Key", key);
			ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1);
			string item4 = "Actor";
			BaseActorComponent component21 = base.Entity.GetComponent<BaseActorComponent>();
			ptr4 = new ValueTuple<string, object>(item4, (component21 != null) ? component21.Owner : null);
			instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
			return;
		}
		this.Blackboard[key] = value;
	}

	// Token: 0x060193D5 RID: 103381 RVA: 0x0073B0FC File Offset: 0x007392FC
	public static void CreateStaticDefaultValue()
	{
		CharacterCustomValueComponent._builtinFormulaFunctions = new Dictionary<string, Func<TFormulaValue[], TFormulaValue>>();
	}

	// Token: 0x060193D6 RID: 103382 RVA: 0x0073B108 File Offset: 0x00739308
	public static void ResetStaticDefaultValue()
	{
		CharacterCustomValueComponent._builtinFormulaFunctions = null;
	}

	// Token: 0x060193D7 RID: 103383 RVA: 0x0073B110 File Offset: 0x00739310
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterCustomValueComponent characterCustomValueComponent = (CharacterCustomValueComponent)componentTemplate;
		if (base.CanResetComponentProperty("AssetDataTable"))
		{
			if (characterCustomValueComponent.AssetDataTable == null)
			{
				this.AssetDataTable = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UDataTable>(this.AssetDataTable), "AssetDataTable"))
			{
				return false;
			}
		}
		return (!base.CanResetComponentProperty("MapCustomValue") || characterCustomValueComponent.MapCustomValue == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, SCustomValueRecordRow>>(this.MapCustomValue), "MapCustomValue")) && (!base.CanResetComponentProperty("Blackboard") || characterCustomValueComponent.Blackboard == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, TFormulaValue>>(this.Blackboard), "Blackboard"));
	}

	// Token: 0x0400C696 RID: 50838
	[Nullable(2)]
	private UDataTable AssetDataTable;

	// Token: 0x0400C697 RID: 50839
	private readonly Dictionary<string, SCustomValueRecordRow> MapCustomValue = new Dictionary<string, SCustomValueRecordRow>();

	// Token: 0x0400C698 RID: 50840
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private static Dictionary<string, Func<TFormulaValue[], TFormulaValue>> _builtinFormulaFunctions;

	// Token: 0x0400C699 RID: 50841
	private readonly Dictionary<string, TFormulaValue> Blackboard = new Dictionary<string, TFormulaValue>();
}
