import api from '../services/api'
import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Paciente extends Component {
    constructor(props) {
        super(props);
        this.state ={
        listaConsulta: [],
        };
    }

    buscarConsultas = async () => {

        const token = await AsyncStorage.getItem('usuario-login')

        const resposta = await api.get('consultas/paciente', {
            headers: {
                'Authorization' : 'Bearer ' + token
            }
        })

        const dadosApi = resposta.data;
        this.setState({ listaConsulta: dadosApi })
        console.log(dadosApi)
    }

    componentDidMount(){
        this.buscarConsultas();
    }

    render(){
        return(
            <View style={styles.main}>
                <View style={styles.mainBody}>
                    <FlatList 
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaConsulta}
                        keyExtractor={(item) => item.nome}
                        renderItem={this.renderizaItem}
                    />
                </View>
            </View>
        )
    }

    renderizaItem= ({item}) => (
        <View style={styles.flatItemRow}>
            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemTitle}>{item.idSituacaoNavigation.situacao1}</Text>
                <View style={styles.flatItem}>
                    <Text style={styles.flatItemInfo}>Data da Consulta: {" "} {Intl.DateTimeFormat("pt-BR").format(new Date(item.dataConsulta))}</Text>
                </View>
                <View style={styles.flatItem}>
                    <Text style={styles.flatItemInfo}>Paciente: {item.idPacienteNavigation.nomePaciente}</Text>
                </View>
                <View style={styles.flatItem}>
                    <Text style={styles.flatItemInfo}>Diagnóstico: {item.descricao}</Text>
                </View>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: '#EFF8FB'
    },

    mainBody: {
        flex: 4,
        backgroundColor: '#EFF8FB',
    },

    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
    },

    flatItemRow: {
        borderBottomLeft: 1,
        borderBottomColor: '#3282B8',
    },

    flatItemContainer: {
        flexDirection:'column',
        flex: 1,
        margin:20,
    },

    flatItemTitle: {
        fontSize: 20,
        color: '#3282B8', 
        textAlign:'left',
    },

    flatItem: {
        flexDirection: 'column',
        textAlign:'left'  
    },

    flatItemInfo: {
        fontSize: 20,
        color:'#3282B8',
        lineHeight: 20,
    },
    
});