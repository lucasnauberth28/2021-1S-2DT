import React, { Component } from "react";
import jwtDecode from "jwt-decode";
import {
  Image,
  StyleSheet,
  Text,
  TextInput,
  View,
  TouchableOpacity,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import api from "../services/api";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      senha: "",
    };
  }

      FazerLogin = async () => {
          console.warn('nauberth')
        console.warn(this.state.email + " " + this.state.senha);
    
        const resposta = await api.post("/login", {
          email: this.state.email,
          senha: this.state.senha,
        });
        const token = resposta.data.token;
    
        await AsyncStorage.setItem("usuario-login", token);
    
        console.warn(token);


        if (jwtDecode(token).role === "2") {
            this.props.navigation.navigate("Medico")
        } else if (jwtDecode(token).role === "3") {
            this.props.navigation.navigate("Paciente")
        }
        
        console.warn('oi')

  };

  render() {
    return (
      <View style={styles.container}>
          <Text
          style={styles.title}
          >Login</Text>

        <TextInput
          style={styles.inputLogin}
          placeholder="Email"
          placeholderTextColor="#3282B8"
          keyboardType="email-address"
          onChangeText={(email) => this.setState({ email })}
        />

        <TextInput
          style={styles.inputLogin}
          placeholder="Senha"
          placeholderTextColor="#3282B8"
          secureTextEntry={true}
          onChangeText={(senha) => this.setState({ senha })}
        />

        <TouchableOpacity style={styles.btnLogin} onPress={this.FazerLogin}>
          <Text style={styles.btnLoginText}>Login</Text>
        </TouchableOpacity>

        <Image source={require('../../assets/Logo.svg')}
                        style={styles.flatItemImgIcon}></Image>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#EFF8FB",
    justifyContent: "center",
    alignItems: "center",
  },


  inputLogin: {
    width: 240,
    marginBottom: 20,
    textAlign:"center",
    fontSize: 18,
    color: "#3282B8",
    borderBottomColor: "#3282B8",
    borderBottomWidth: 2,
    borderTopColor: "#3282B8",
    borderTopWidth: 2,
    borderLeftColor: "#3282B8",
    borderLeftWidth: 2,
    borderRightColor: "#3282B8",
    borderRightWidth: 2,
    borderRadius:15,
  },

  btnLogin: {
    alignItems: "center",
    justifyContent: "center",
    height: 35,
    width: 170,
    backgroundColor: "#3282B8",
    borderColor: "#3282B8",
    borderWidth: 1,
    borderRadius: 15,
    marginTop: 5,
  },

  btnLoginText: {
    fontSize: 18,
    fontWeight: "bold",
    color: "#EFF8FB",
    letterSpacing: 6,
  },
  title:{
      color:"#3282B8",
      fontSize: 25,
      marginBottom:20,
  },

  flatItemImgIcon: {
    width: 120,
    height: 36,
    margin: 10,
  },
});